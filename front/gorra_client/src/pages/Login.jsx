import React, { useState } from 'react';
import {
  MDBContainer,
  MDBCol,
  MDBRow,
  MDBBtn,
  MDBIcon,
  MDBInput,
  MDBCheckbox
}
from 'mdb-react-ui-kit';
import gorraLogo from "../pages/resources/gorra-logo.jpg"
import { useNavigate } from 'react-router-dom';
import { Form } from 'react-bootstrap';

function Login() {
  const navigate = useNavigate();

  const handleClick = (path) => {
    navigate(path);
  };

  const [validated, setValidated] = useState(false);

  const handleSubmit = (event) => {
    const form = event.currentTarget;
    if (form.checkValidity() === false) {
      event.preventDefault();
      event.stopPropagation();
    }else{
        handleClick("/home")
    }

    setValidated(true);
  };

  return (
    <Form noValidate validated={validated} onSubmit={handleSubmit} fluid className="p-3 my-1">

      <MDBRow>

        <MDBCol col='10' md='6'className='d-flex mb-3 justify-content-center'>
          <img src={gorraLogo} class="img-fluid" alt="Phone image" className="rounded-pill"/>
        </MDBCol>

        <MDBCol col='4' md='6'>

        <Form.Label>Email</Form.Label>
          <Form.Control
            required
            type="text"
            placeholder="Email"
            size='lg'
          />
        <Form.Control.Feedback type="invalid">Email invalido</Form.Control.Feedback>

        <Form.Label>Contraseña</Form.Label>
          <Form.Control
            required
            type="password"
            placeholder="Contraseña"
            size='lg'
          />
        <Form.Control.Feedback type="invalid">Contraseña invalida</Form.Control.Feedback>

        <div className="d-flex justify-content-center mb-4">
        <a href="/register">Todavía no tienes una cuenta? Registrate</a>
        </div>

        <MDBBtn type='submit' className="mb-4 w-100" size="lg">
            Ingresar
        </MDBBtn>

        </MDBCol>

      </MDBRow>

    </Form >
  );
}

export default Login;