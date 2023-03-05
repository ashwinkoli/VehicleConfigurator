import axios from 'axios';
import React from 'react';
import { useState, useEffect } from "react";
import 'bootstrap/dist/css/bootstrap.min.css';  
import {Nav, Navbar, Container, NavDropdown, Col, Row} from 'react-bootstrap';  
import Form from 'react-bootstrap/Form'
import Button from 'react-bootstrap/Button';
import {
  BrowserRouter as Router,
  Switch,
  Route,
  useParams,
  Link,
} from "react-router-dom";
import Display from './Display';
import DefaultConfig from './DefaultConfig';

export default function Segment(props) {

  const [options1, setOptions1] = useState([]);
  const [options2, setOptions2] = useState([]);
  const [options3, setOptions3] = useState([]);
  const [selectedOption1, setSelectedOption1] = useState('');
  const [selectedOption2, setSelectedOption2] = useState('');
  const [selectedOption3, setSelectedOption3] = useState('');

  const [quantity, setQuantity] = useState('');


  useEffect(() => {
    
    axios.get('https://localhost:7227/api/SegmentMasters/')
      .then(response => {
        setOptions1(response.data);
      })
      .catch(error => {
        console.log(error);
      });
  }, [selectedOption1]);

  useEffect(() => {
    if (selectedOption1) {
      axios.get("https://localhost:7227/api/MfgMasters/"+selectedOption1)
        .then(response => {
          setOptions2(response.data);  
          console.log(response.data);
        })
        .catch(error => {
          console.log(error);
        });
    }
  }, [selectedOption1]);

  useEffect(() => {
    if (selectedOption2) {
      axios.get("https://localhost:7227/api/ModelMasters/"+selectedOption2)
        .then(response => {
          setOptions3(response.data);  
        })
        .catch(error => {
          console.log(error);
        });
    }
  }, [selectedOption2]);

  const handleOption1Change = (event) => {
    setSelectedOption1(event.target.value);
    
  }

  const handleOption2Change = (event) => {
    setSelectedOption2(event.target.value);
    
  }

  const handleOption3Change = (event) => {
    setSelectedOption3(event.target.value);
    
  }


  const handleInputChange = (event) => {
    const value = event.target.value;
    
    // Custom validation to check if value is between 10 and 50 characters
    if (parseInt(value) < 10 || parseInt(value) > 50) {
      event.target.setCustomValidity('Tag number should be between 10 and 50 characters.');
    } else {
      event.target.setCustomValidity('');
    }
    
    setQuantity(value);
  }
  
  
  return (
    <>
  <Container className="pos" >
    <Row>
      <Col md={{ span: 6, offset: 3 }}>
        <Form.Label>
          <label>
            <h3><b><u>Select Your Data</u></b></h3>
          </label>
        </Form.Label>
        <Form.Group className="mb-3">
          <Form.Label className="fw-bold">Segment</Form.Label>
          <Form.Select className="form-select" value={selectedOption1} onChange={handleOption1Change} required>
            <option>--Select--</option>
            {options1.map(p => (
              <option key={p.segId} value={p.segId}>{p.segName}</option>
            ))}
          </Form.Select>

          <Form.Label className="fw-bold">Manufacturer</Form.Label>
          <Form.Select className="form-select" value={selectedOption2} onChange={handleOption2Change} required>
            <option>--Select--</option>
            {options2.map(option => (
              <option key={option.mfgId} value={option.mfgId}>{option.mfgName}</option>
            ))}
          </Form.Select>

          <Form.Label className="fw-bold">Model</Form.Label>
          <Form.Select className="form-select" value={selectedOption3} onChange={handleOption3Change} required>
            <option>--Select--</option>
            {options3.map(option => (
              <option key={option.modelId} value={option.modelId}>{option.modelName}</option>
            ))}
          </Form.Select>

          <Form.Label className="fw-bold">Quantity</Form.Label>
          <input type="number" className="form-control" value={quantity} placeholder='Enter Quantity' 
  onChange={handleInputChange} pattern="[0-9]{10,50}" required />

        </Form.Group>

        <Button href={`/DefaultConfig/${selectedOption3}/${quantity}`} className="btn btn-primary" disabled={!selectedOption1 || !selectedOption2 || !selectedOption3 || !quantity}>Next</Button>
      </Col>
    </Row>
  </Container>
</>

    );
}
