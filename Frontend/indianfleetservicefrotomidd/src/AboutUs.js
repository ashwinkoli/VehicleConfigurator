import React from "react";
import Carousel from 'react-bootstrap/Carousel';
import Card from 'react-bootstrap/Card';

import { Col,Container, Row,Button } from "react-bootstrap";


import Image from 'react-bootstrap/Image'
function AboutUs()
{
    return(
        <div>
        <div height="100" width="200">
        <Carousel fade>
      <Carousel.Item>
        <img
          className="d-block w-100"
          src="images\mercedes.jpg"
          alt="First slide"
        />
        <Carousel.Caption>
          <h3>First slide label</h3>
          <p>Nulla vitae elit libero, a pharetra augue mollis interdum.</p>
        </Carousel.Caption>
      </Carousel.Item>
      <Carousel.Item>
        <img
          className="d-block w-100"
          src="images\xuv700.webp"
          alt="Second slide"
        />

        <Carousel.Caption>
          <h3>Second slide label</h3>
          <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit.</p>
        </Carousel.Caption>
      </Carousel.Item>
      <Carousel.Item>
        <img
          className="d-block w-100 "
          src="images\Verna.webp"
          alt="Third slide"
        />

        <Carousel.Caption>
          <h3>Third slide label</h3>
          <p>
            Praesent commodo cursus magna, vel scelerisque nisl consectetur.
          </p>
        </Carousel.Caption>
      </Carousel.Item>
    </Carousel>
    </div>
    <div>
    <Row>
     <Col md={{ span: 6, offset: 2 }}>
    <Card style={{ width: '57rem' }}className="mt-4 p">
      <Card.Body>
        <Card.Title>About Us</Card.Title>
        <Card.Text>
         
            <p>India fleet services was was established 
            in 1999 by lina,ashwin,ashu with a aim of making car leasing business affordable and easily available for small car rental vendors.</p>

        </Card.Text>
        <Button variant="primary" href="/">Home</Button>
      </Card.Body>
    </Card>
    </Col>
    </Row>
    </div>
   
    </div>
   
    )
}
export default AboutUs;