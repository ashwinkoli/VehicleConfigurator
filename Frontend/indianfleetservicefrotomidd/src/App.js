import logo from './logo.svg';
import 'bootstrap/dist/css/bootstrap.min.css';
import './App.css';

import NavigationBar from './NavigationBar';
import React from 'react';
import ReactDOM from 'react-dom/client';
import reportWebVitals from './reportWebVitals';
import { BrowserRouter, Routes, Route } from "react-router-dom";
import Segment from './Segment';
import Display from './Display';
import Registration from './Registration';
import Show from './Show';
import AboutUs from './AboutUs';
import Login from './Login';

import DefaultConfig from './DefaultConfig';
import Configure from './Configure';
import { Invoice } from './Invoice';
import Home from './Home';
import ContactUs from './ContactUs';



function App() {
  return (
    <div>
    <NavigationBar/>
    <BrowserRouter>
      <Routes>
        <Route path="/" element={<Home />} />
        <Route path="Registration" element={<Registration />} />
        <Route path="Segment" element={<Segment />} />
        
        <Route path="/ContactUs" element={<ContactUs />} />
        
        <Route path="AboutUs" element={<AboutUs />} />
        <Route path="Login" element={<Login />} />
        <Route path="Invoice/:price/:quantity/:name/:value" element={<Invoice />} />
        <Route path="Configure/:selectedOption3/:quantity" element={<Configure />} />
        <Route path="DefaultConfig/:selectedOption3/:quantity" element={<DefaultConfig />} />
      </Routes>
    </BrowserRouter>
    </div>
  );
}

export default App;
