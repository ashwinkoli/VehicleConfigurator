import axios from 'axios';
import Button from 'react-bootstrap/Button';
import { useState, useEffect } from "react";
import { Nav, Navbar, Container, NavDropdown, Col, Row } from 'react-bootstrap';
import { useParams } from 'react-router-dom';
import Dropdown from 'react-bootstrap/Dropdown';
import Form from 'react-bootstrap/Form'

export default function Configure() {

  const { selectedOption3 } = useParams()
  const { quantity } = useParams();

  const [modelDetails, setMode] = useState([])
  const [corefeat, setCore] = useState([])
  const [AlterComp, setAlteComp] = useState([])
  const [opt1, setAlteOpt1] = useState('')
  const [modName, setMod] = useState([]);
  const [name, setname] = useState('');
  const [value, setvalue] = useState('');
  

  useEffect(() => {
    axios.get(`https://localhost:7227/api/ModelMasters/${selectedOption3}/1`)
      .then(response => {
        setMode(response.data);
        console.log(modelDetails);
      }) 
      .catch(error => {
        console.log(error);
      });
  }, []);

  useEffect(() => {
    axios.get(`https://localhost:7227/api/ComponentMasters/${selectedOption3}/C`
    )
      .then(response => setCore(response.data))
      .catch(error => console.error(error));
  }, []);

  useEffect(() => {
    axios.get(`https://localhost:7227/api/AlternateComponentMasters/${selectedOption3}/V`)
      .then(response => setAlteComp(response.data))
      .catch(error => console.error(error));
  }, [setAlteOpt1]);



  const TypeS = AlterComp.filter(obj => obj.altCompType == 'S')
  const TypeSWithZero = TypeS.filter(obj => obj.deltaPrice == 0)

  //   THIS IS DICTIONARY CREATION(DUPLICATE KEY NOT ALLOWED) 
  //  IN WHICH COMPONENTS HAVING DELTA_PRICE ZERO  ARE STORED.
  const stanChange = TypeSWithZero.reduce((acc, curr) => {   
    acc[curr.compId] = curr.altCompId;
    return acc;
  }, {});
  console.log(stanChange)

// changing value of delta-price = 0 component(18,22,28) 
//with the selected altcomponent id
  const handOnclick1 = (event) => {
    const { name, value } = event.target;
    stanChange[name] = value;
  }

  const TypeI = AlterComp.filter(obj => obj.altCompType == 'I')
  const TypeIWithZero = TypeI.filter(obj => obj.deltaPrice == 0)

  const inteChange = TypeIWithZero.reduce((acc, curr) => {
    acc[curr.compId] = curr.altCompId;
    return acc;
  }, {});

  const handOnclick2 = (event) => {
    const { name, value } = event.target;
    inteChange[name] = value;
  }




  const TypeE = AlterComp.filter(obj => obj.altCompType == 'E')
  const TypeEWithZero = TypeE.filter(obj => obj.deltaPrice == 0)

  const exteChange = TypeEWithZero.reduce((acc, curr) => {
    acc[curr.compId] = curr.altCompId;
    return acc;
  }, {});

  
  const handOnclick3 = (event) => {
    const { name, value } = event.target;
    exteChange[name] = value;
  }

  const handOnclick4 = (event) => {
    const name = event.target.name;
    const value = event.target.value;
    setname(name);
    setvalue(value);
  }

  const [price, setPrice] = useState(null);
// for calculating delta prices of selected component 
  function handleClick() {
    const standAltCompId = Object.entries(stanChange).map(([key, value]) => { return parseInt(value) });
    const sumStandDeltaPrices = TypeS
      .filter(S => standAltCompId.includes(S.altCompId))
      .reduce((acc, S) => acc + S.deltaPrice, 0);

    console.log(sumStandDeltaPrices);


    const exteAltCompId = Object.entries(exteChange).map(([key, value]) => { return parseInt(value) });
    const sumExteDeltaPrices = TypeE
      .filter(E => exteAltCompId.includes(E.altCompId))
      .reduce((acc, S) => acc + S.deltaPrice, 0);

    console.log(sumExteDeltaPrices);

    const inteAltCompId = Object.entries(inteChange).map(([key, value]) => { return parseInt(value) });
    const sumInteDeltaPrices = TypeI
      .filter(I => inteAltCompId.includes(I.altCompId))
      .reduce((acc, S) => acc + S.deltaPrice, 0);
// final price calculation delta+ Standerd Price 
    console.log(sumInteDeltaPrices);
    
    const finalPrice = eval(`${sumStandDeltaPrices}+${sumExteDeltaPrices}+${sumInteDeltaPrices}+${modelDetails.map(m => { return parseInt(m.basicPrice) })}+${0.12 * modelDetails.map(m => { return parseInt(m.basicPrice) })}*${quantity}`);
    console.log(modelDetails.map(m => { return m.basicPrice }));
    console.log(finalPrice);
    setPrice(finalPrice);
  }


  return (


    <Container style={{marginTop: '60px'}}>
      <Row>
        <Col>
          {modelDetails.map(p => (<h3 key={p.modelId} name={p.modelName} value={p.modelId} onClick={handOnclick4}>{p.mfgName} - {p.modelName}</h3>))}
          <ul>
            {corefeat.map(p => (
              <li key={p.compId}>{p.compName}</li>
            ))}
          </ul>
          {modelDetails.map(p => (<img key={p.modelId} src={p.imagPath} alt="My Image" style={{ 
          width: '600px', 
          height: 'auto', 
          float: 'left', 
          marginRight: '20px'
        }} />))}
        
          <Button variant="primary" onClick={handleClick}>Get Price</Button>
          <Form.Group>
  <Form.Label>Final Price After Configure</Form.Label>
  <Form.Control type="text" value={price} readOnly />
</Form.Group>

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
              href={`/DefaultConfig/${selectedOption3}/${quantity}` }
              variant="primary"
              disabled={!selectedOption3}
            >
              Previous
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
        </Col>
        <Col style={{marginTop: '80px'}}>
          <Form>
            <legend>Configurable Item</legend>
            <h5>Standard Features</h5>
            {TypeSWithZero.length > 0 ? (
              <>
                {TypeSWithZero.map(p => (
                  <Form.Group key={p.compId}>
                    <Form.Label>{p.compName}</Form.Label>
                    <Form.Control as="select" name={p.compId} onChange={handOnclick1}>
                      <option value="" disabled selected>Select an option</option>
                      {TypeS.filter(obj => obj.compId == p.compId).map(s => (
                        <option key={s.compId} value={s.altCompId}>
                         {s.compName}
                        </option>
                      ))}
                    </Form.Control>
                  </Form.Group>
                ))}
              </>
            ) : (
              <p>No Configurable item</p>
            )}

            <h5>Interior Features</h5>
            {TypeI.length > 0 ? (
              TypeIWithZero.map(p => (
                <Form.Group key={p.compId}>
                  <Form.Label>{p.compName}</Form.Label>
                  <Form.Control as="select" name={p.compId} onChange={handOnclick2}>
                    <option value="" disabled selected>Select an option</option>
                    {TypeI.filter(obj => obj.compId == p.compId).map(i => (
                      <option key={i.compId} value={i.altCompId}>
                        {i.compName}
                      </option>
                    ))}
                  </Form.Control>
                </Form.Group>
              ))
            ) : (
              <p>No Configurable item</p>
            )}

            <h5>Exterior Features</h5>
            {TypeEWithZero.length > 0 ? (
              TypeEWithZero.map(p => (
                <Form.Group key={p.compId}>
                  <Form.Label>{p.compName}</Form.Label>
                  <Form.Control as="select" name={p.compId} onChange={handOnclick3}>
                    <option value="" disabled selected>Select an option</option>
                    {TypeE.filter(obj => obj.compId == p.compId).map(e => (
                      <option key={e.altCompId} value={e.altCompId}>
                        {e.compName}
                      </option>
                    ))}
                  </Form.Control>
                </Form.Group>
              ))
            ) : (
              <p style={{ color: "red" }}>No Configurable item</p>
            )}

            <br></br>
          </Form>
        </Col>
      </Row>
    </Container>

  );
}


