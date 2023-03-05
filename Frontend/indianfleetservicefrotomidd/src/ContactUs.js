import React from 'react';
import { MDBBtn, MDBTextArea } from 'mdb-react-ui-kit';
import { Container, Col, Row } from "react-bootstrap";


function ContactUs() {
    const submitForm = () =>{
        // Get form data

        //let message = document.getElementById("message").value;

        // Send form data via email
        var mailtoLink = "mailto:shyamshankar997@example.com" +
            "?subject=Vehicle Configurator Contact Us Form"
                    // Open email client
    window.location.href = mailtoLink;

    // Show acknowledgement message
    alert("Thank you for contacting us! We will get back to you as soon as possible.");
    
    // Redirect user to previous page
    window.history.back();
}
    return (

        
        <Container className="mt-5 p">
            <Row>
                <Col></Col>

                <Col xs={4}>
                    <form id='form' className='text-center' style={{ width: '100%', maxWidth: '300px' }} align="center" onSubmit={submitForm}>
                        <h2>Contact us</h2>
                        <br />
                        <table align="center">
                            <tr>
                                <th align="right">
                                    <h6>Company Name :</h6>
                                </th>
                                <td>
                                    <h6 align="left">Vehicle Configurator</h6>
                                </td>
                            </tr>
                            <br />
                            <tr>
                                <th>
                                    <h6 align="right">Contact Person :</h6>
                                </th>
                                <td>
                                    <h6 align="left">Group 12</h6>
                                </td>
                            </tr>
                            <br />
                            <tr>
                                <th>
                                    <h6 align="right">Phone No :</h6>
                                </th>
                                <td>
                                    <h6 align="left">+91-9876543210</h6>
                                </td>
                            </tr>
                            <br />
                        </table>
                        

                        {/* <MDBCardText label='Name' v-model='name' wrapperClass='mb-4'>Company Name: India Fleet Services Pvt.Ltd.</MDBCardText>

            <MDBInput type='email' label='Email address' v-model='email' wrapperClass='mb-4' />

            <MDBInput label='Subject' v-model='subject' wrapperClass='mb-4' /> */}

                        <MDBTextArea wrapperClass='mb-4' placeholder='Comments Here' />

                        {/* <MDBCheckbox wrapperClass='d-flex justify-content-center' label='Send me copy' /> */}

                        <MDBBtn color='primary' block className='my-4' value="submit">
                            Send
                        </MDBBtn>
                    </form>
                    
                </Col>
                <Col></Col>
            </Row>
        </Container>
    );
}

export default ContactUs;