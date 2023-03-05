import axios from 'axios';
import './App.css';
import Button from 'react-bootstrap/Button';
import { useState, useEffect } from "react";
import {Nav, Navbar, Container, NavDropdown, Col, Row} from 'react-bootstrap';  
import { useParams } from 'react-router-dom';
import Dropdown from 'react-bootstrap/Dropdown';
import { useHistory } from 'react-router-dom';

export default function DefaultConfig(params)
{

  const [name, setname] = useState('');
  const [value, setvalue] = useState('');
  const {selectedOption3} = useParams()
  const {quantity} = useParams()

  const [core, setCore] = useState([]);
  const [stand, setStandard] = useState([]);
  const [inter, setInterior] = useState([]);
  const [exter, setExterior] = useState([]);
  const [price, setPrice] =useState([]);

  const [sel1, set1] = useState('');
  const [sel2, set2] = useState('');
  const [sel3, set3] = useState('');
  const [sel4, set4] = useState('');
  const [pri5, set5] = useState('');
  

  useEffect(() => {
    
    axios.get(`https://localhost:7227/api/ModelMasters/${selectedOption3}/1`)
      .then(response => {
        setPrice(response.data);
        console.log(quantity);

      })
      .catch(error => {
        console.log(error);
      });
  }, [set5]);


  useEffect(() => {
    axios.get(`https://localhost:7227/api/ComponentMasters/${selectedOption3}/C`
)
.then(response => setCore(response.data))
.catch(error => console.error(error));
  }, [set1]);

  useEffect(() => {
axios.get(`https://localhost:7227/api/ComponentMasters/${selectedOption3}/S`)
.then(response => setStandard(response.data))
.catch(error => console.error(error));
  }, [set2]);

  useEffect(() => {
axios.get(`https://localhost:7227/api/ComponentMasters/${selectedOption3}/I`)
.then(response => setInterior(response.data))
.catch(error => console.error(error));
  }, [set3]);


  useEffect(() => {
axios.get(`https://localhost:7227/api/ComponentMasters/${selectedOption3}/E`)
.then(response => setExterior(response.data))
.catch(error => console.error(error));
  }, [set4]);

  const handOnclick4 = (event) => {
    const name = event.target.name;
    const value = event.target.value;
    setname(name);
    setvalue(value);
  }


return (
  <>
  
  {price.map(p => (<img key={p.modelId} name={p.modelName} src={p.imagPath} value={p.modelId} alt="My Image" style={{ 
          width: '300px', 
          height: 'auto', 
          float: 'left', 
          marginRight: '20px',
          marginTop: '180px'
        }} onClick={handOnclick4} />))}
  <Container className="pos" style={{marginTop: '80px'}}>
  {price.map(p => (<h3 key={p.modelId} name={p.modelName} value={p.modelId} onClick={handOnclick4} style={{marginTop: '80px'}}>{p.mfgName} - {p.modelId}</h3>))}
    <Row>
      <Col md={{ span: 10, offset: 2 }}>
      <h1 className=" mb-4">Default Configuration</h1>
        <table>
          <tbody>
        <tr>
              <td>
        <h3>Core Feature</h3>
        <ul>
          {core.map((c) => (
            <li key={c.compId}>
              {c.compId}
              {c.compName}
            </li>
          ))}
        </ul>
        </td>
        <td>
        <h3>Standard Feature</h3>
        <ul>
          {stand.map((s) => (
            <li key={s.compId}>
              {s.compId}
              {s.compName}{" "}
            </li>
          ))}
        </ul>
        </td>
        </tr>
        <tr>
          <td>
        <h3>Interior Feature</h3>
        <ul>
          {inter.map((i) => (
            <li key={i.compId}>
              {i.compId}
              {i.compName}
            </li>
          ))}
        </ul>
        </td>
        <td>
        <h3>Exterior Feature</h3>
        <ul>
          {exter.map((e) => (
            <li key={e.compId}>
              {e.compId}
              {e.compName}
            </li>
          ))}
        </ul>
        </td>
        </tr>
        </tbody>
        </table>
      </Col>
    </Row>
    <table className="table">
      <thead>
        <tr>
          <th>Add Taxes</th>
          {price.map((e) => (
            <th key={e.modelId}>
              Base Price: {e.basicPrice} <br />
              S.T. @12%: {(((e.basicPrice)* 12) / 100)}
            </th>
          ))}
          <th>Quantity:{quantity}</th>
        </tr>
      </thead>
      <tbody>
        <tr>
          <td>Total</td>
          {price.map((e) => (
            <td key={e.modelId} name={e.mfgName} value={(e.basicPrice*quantity)+ ((e.basicPrice*quantity) * 0.12)} onClick={handOnclick4}>{(e.basicPrice*quantity)+ ((e.basicPrice*quantity) * 0.12)}</td>
          ))}
          <td>

          </td>
        </tr>
      </tbody>
    </table>
    <br />
    <table className="border-less table">
      <thead>
        <tr>
          <th>
            <Button href={`/Invoice/${price}/${quantity}/${name}/${value}`} variant="success">
              Confirm
            </Button>
          </th>
          <th>
            <Button
              href={`/Configure/${selectedOption3}/${quantity}` }
              variant="primary"
              disabled={!selectedOption3}
            >
              Configure
            </Button>
          </th>
          <th>
            <Button href="/Segment" variant="danger">
              Modify
            </Button>
          </th>
        </tr>
      </thead>
    </table>
  </Container>
</>

        );
}