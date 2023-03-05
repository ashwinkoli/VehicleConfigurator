import React, { useEffect, useState } from "react";
import axios from 'axios';
import {
    MDBCard,
    MDBCardBody,
    MDBContainer,
    MDBRow,
    MDBCol,
    MDBBtn,
    MDBIcon,
    MDBTypography,
    MDBTable,
    MDBTableHead,
    MDBTableBody,
} from "mdb-react-ui-kit";
import { useParams } from "react-router-dom";


export function Invoice() {
    const {price} = useParams();
    const {quantity} = useParams();
    const {name} = useParams();
    const {value} = useParams();
    const submitForm = () =>{
        var mailtoLink = "mailto:shyamshankar997@example.com" +
            "?subject=Vehicle Configurator Contact Us Form"
                    // Open email client
    window.location.href = mailtoLink;

    // Show acknowledgement message
    alert("Thank you for contacting us! We will get back to you as soon as possible.");
    
    // Redirect user to previous page
    window.history.back();
}
const [userData, setUserData] = useState('');

useEffect(() => {
    axios.get(`https://localhost:7227/api/UserDatas/1`)
      .then(response => {
        setUserData(response.data);
      })
      .catch(error => {
        console.log(error);
      });
  }, []);

    return (
        <MDBContainer className="py-5" >
            <MDBCard className="p-4">
                <MDBCardBody>
                    <MDBContainer className="mb-2 mt-3">
                        <MDBRow className="d-flex align-items-baseline">
                            <MDBCol xl="9">
                                <p style={{ color: "#7e8d9f", fontSize: "20px" }}>
                                    Invoice &gt; &gt; <strong>ID: #123-123</strong>
                                </p>
                            </MDBCol>
                            <MDBCol xl="3" className="float-end">
                                <MDBBtn
                                    color="light"
                                    ripple="dark"
                                    className="text-capitalize border-0"
                                >
                                    <MDBIcon fas icon="print" color="primary" className="me-1" />
                                    Print
                                </MDBBtn>
                                <MDBBtn
                                    color="light"
                                    ripple="dark"
                                    className="text-capitalize border-0 ms-2"
                                >
                                    <MDBIcon
                                        far
                                        icon="file-pdf"
                                        color="danger"
                                        className="me-1"
                                        onClick={submitForm}
                                    />
                                    Email
                                </MDBBtn>
                                <hr />
                            </MDBCol>
                        </MDBRow>
                    </MDBContainer>
                    <MDBContainer>
                        <MDBCol md="12" className="text-center">
                            <MDBIcon
                                fab
                                icon="mdb"
                                size="4x"
                                className="ms-0 "
                                style={{ color: "#5d9fc5" }}
                            />
                            <p className="pt-0">IndianFleetService.com</p>
                        </MDBCol>
                    </MDBContainer>
                    <MDBRow>
                        <MDBCol xl="8">
                            <MDBTypography listUnStyled>
                                <li className="text-muted">
                                    To: <span style={{ color: "#5d9fc5" }}>John Lorem</span>
                                </li>
                                <li className="text-muted">Street, City</li>
                                <li className="text-muted">State, Country</li>
                                <li className="text-muted">
                                    <MDBIcon fas icon="phone-alt" /> 123-456-789
                                </li>
                            </MDBTypography>
                        </MDBCol>
                        <MDBCol xl="4">
                            <p className="text-muted">Invoice</p>
                            <MDBTypography listUnStyled>
                                <li className="text-muted">
                                    <MDBIcon fas icon="circle" style={{ color: "#84B0CA" }} />
                                    <span className="fw-bold ms-1">ID:</span>#123-456
                                </li>
                                <li className="text-muted">
                                    <MDBIcon fas icon="circle" style={{ color: "#84B0CA" }} />
                                    <span className="fw-bold ms-1">Creation Date: </span>Jun
                                    23,2021
                                </li>
                                <li className="text-muted">
                                    <MDBIcon fas icon="circle" style={{ color: "#84B0CA" }} />
                                    <span className="fw-bold ms-1">Status:</span>
                                    <span className="badge bg-warning text-black fw-bold ms-1">
                                        Unpaid
                                    </span>
                                </li>
                            </MDBTypography>
                        </MDBCol>
                    </MDBRow>
                    <MDBRow className="my-2 mx-1 justify-content-center">
                        <MDBTable striped borderless>
                            <MDBTableHead
                                className="text-white"
                                style={{ backgroundColor: "#84B0CA" }}
                            >
                                <tr>
                                    <th scope="col">#</th>
                                    <th scope="col">modelName</th>
                                    <th scope="col">Qty</th>
                                    {/* <th scope="col">Unit Price</th> */}
                                    <th scope="col">Amount</th>
                                </tr>
                            </MDBTableHead>
                            <MDBTableBody>
                                <tr>
                                    <th scope="row">1</th>
                                    <td>{name}{value}</td>
                                    <td>{quantity}</td>
                                    {/* <td>$200</td> */}
                                    <td>{price}</td>
                                </tr>

                            </MDBTableBody>
                        </MDBTable>
                    </MDBRow>
                    <MDBRow>
                        <MDBCol xl="8">
                            <p className="ms-3">
                                Add additional notes and payment information
                            </p>
                        </MDBCol>
                        <MDBCol xl="3">
                            <MDBTypography listUnStyled>
                                {/* <li className="text-muted ms-3">
                                    <span class="text-black me-4">SubTotal</span>$1110
                                </li> */}
                                {/* <li className="text-muted ms-3 mt-2">
                                    <span class="text-black me-4">Tax(15%)</span>$111
                                </li> */}
                            </MDBTypography>
                            <p className="text-black float-start">
                                <span className="text-black me-3"> Total Amount</span>
                                <span style={{ fontSize: "25px" }}>Rs.{price}</span>
                            </p>
                        </MDBCol>
                    </MDBRow>
                    <hr />
                    <MDBRow>
                        <MDBCol xl="10">
                            <p>Thank you for placing order.</p>
                        </MDBCol>
                        <MDBCol xl="2">
                            {/* <MDBBtn
                                className="text-capitalize"
                                style={{ backgroundColor: "#60bdf3" }}
                            >
                                Pay Now
                            </MDBBtn> */}


                        </MDBCol>
                    </MDBRow>
                </MDBCardBody>
            </MDBCard>
        </MDBContainer>
    );
}

// date name model qty price emailbutton print