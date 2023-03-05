import React, { useState } from "react";
import { Link, useNavigate } from "react-router-dom";
import axios from 'axios';
import { Container, Col, Row, Button, ButtonGroup, Card } from "react-bootstrap";
import Form from "react-bootstrap/Form";

function Login() {
    const [companyName, setCompanyName] = useState("");
    const [password, setPassword] = useState("");
    const [error, setError] = useState("");
    const [userData, setUserData] = useState("");
    const navigate = useNavigate();
    const [auth, setAuth] = useState();

    // const handleSubmit = async (e) => {
    //     e.preventDefault();
    //     try {
    //       const response = await axios.post('/api/token', { companyName, password });
    //       localStorage.setItem('token', response.data.token);
    //       window.location.href = '/Welcome' // redirect to dashboard page on successful login
    //     } catch (error) {
    //       setErrorMessage('Invalid credentials');
    //     }
    //   }

    const handleSubmit = async (event) => {
        event.preventDefault();
        const requestOption = {
            method: "POST",
            headers: {
                "Content-Type": "application/json",
            },
            body: JSON.stringify({ CompanyName: companyName, Password: password }),
        };

        
        try {
            let data = await fetch("https://localhost:7145/api/Token", requestOption);
            data.json().then((res) => {
                if (res) {
                    setAuth(res)
                    localStorage.setItem('currentUser', JSON.stringify(res))
                    navigate("/Welcome")
                } 
                if (error) {
                    console.log(`error`)
                    setError('Invalid credentials');
                }
            })

        } catch (e) {
            console.log(e);
            setError('Invalid credentials');
        }
    };

    return (

        <Container className="mt-5 p">
            <Row>
                <Col></Col>
                <Col xs={4}>
                    <Card className="shadow-lg">
                        <Card.Header style={{ backgroundColor: "warning" }}>
                            <h3 align="center">Login</h3>
                        </Card.Header>
                        <Card.Body>
                            <Form>
                                <Form.Group className="mb-3" controlId="formBasicLogin" value={companyName} name="username" >
                                    <Form.Label>Username</Form.Label>
                                    <Form.Control type="text" placeholder="Enter Username"
                                        onChange={(e) => setCompanyName(e.target.value)} required />
                                    {/* <Form.Text className="text-muted">
                                        We'll never share your Username & Password with anyone else.
                                    </Form.Text> */}
                                </Form.Group>

                                <Form.Group className="mb-3" controlId="formBasicPassword" value={password} name="password" >
                                    <Form.Label>Password</Form.Label>
                                    <Form.Control type="password" placeholder="Password"
                                        onChange={(e) => setPassword(e.target.value)} required />
                                </Form.Group>

                                <Form.Group className="mb-3" align="center">
                                    <ButtonGroup className="me-4" aria-label="First group">
                                        <Button href="/Segment" variant="warning" type="submit" disabled={!companyName || !password}>Login</Button>
                                    </ButtonGroup>
                                    <br /><br />
                                    <ButtonGroup className="me-4" aria-label="Second group">
                                        <Button variant="warning" href="#">Forget Password</Button>
                                    </ButtonGroup>
                                </Form.Group>

                            </Form>
                        </Card.Body>
                    </Card>
                </Col>
                <Col></Col>
            </Row>
        </Container>
    )
}
export default Login;