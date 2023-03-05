import React from "react";
import { MDBContainer } from "mdb-react-ui-kit";
import { Carousel,Ratio,Container,Col,Row,Card,Button,ButtonGroup } from "react-bootstrap";

export default function Home()
{
    return(
      <div>
            <Carousel>
      <Carousel.Item>
      <Ratio aspectRatio={50}>
        <div className="wrapper ">
      <video className="slider-video w-100" src="images\HomeVideo.mp4"  loop
            autoPlay
            muted>
       <source src="images\HomeVideo.mp4" type="video/mp4"></source>
       </video>
       </div>
       </Ratio>
      </Carousel.Item>
    </Carousel>
    </div>

    )
}