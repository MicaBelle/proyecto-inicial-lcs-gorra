import React, { useState } from 'react';
import {
  MDBCol,
  MDBRow,
  MDBBtn
} from 'mdb-react-ui-kit';
import newGorraLogo from "../pages/resources/gorra.png"
import { useNavigate } from 'react-router-dom';
import { Form } from 'react-bootstrap';
import { postCitizenLogin } from '../services/citizenService';
import Swal from 'sweetalert2';

function Login() {
  const navigate = useNavigate();

  const handleClick = (path) => {
    navigate(path);
  };

  // Estado para guardar los valores del formulario
  const [formData, setFormData] = useState({
    citizenUserName: '',
    citizenPassword: ''
  });

  const [validated, setValidated] = useState(false);

  // Actualiza los valores del formulario
  const handleChange = (event) => {
    const { name, value } = event.target;
    setFormData({
      ...formData,
      [name]: value
    })
  };

  // Maneja el envío del formulario
  const handleSubmit = async (event) => {
  
      event.preventDefault()

      try {
        // Hacer la petición a la API de autenticación
        const response = await postCitizenLogin(formData)

        if (response.succeeded) {
          const id = JSON.stringify(response.data.id)

          localStorage.setItem("user", id)
          handleClick("/home")
        } else {
          Swal.fire({
            title: "Email y/o contraseña incorrecta. Vuelva a intentarlo.",
            icon: "error",
            confirmButtonColor: "#0d6efd"
          })
        }
      } catch (error) {
        Swal.fire({
          title: "Email y/o contraseña incorrecta. Vuelva a intentarlo.",
          icon: "error",
          confirmButtonColor: "#0d6efd"
        })
      }
    }

  return (
    <Form noValidate validated={validated} onSubmit={handleSubmit} className="p-3 my-1">
      <MDBRow>
        <MDBCol col='10' md='6'className='d-flex mb-3 justify-content-center'>
          <img src={newGorraLogo} className="img-fluid rounded-pill" alt="Phone image" />
        </MDBCol>
        <MDBCol col='4' md='6'>
          <Form.Label>Email</Form.Label>
          <Form.Control
            required
            type="email" // Usar el tipo email para validar correos
            placeholder="Email"
            size='lg'
            name="citizenUserName" // Agregar el nombre del input
            value={formData.citizenUserName}
            onChange={handleChange} // Manejar el cambio
          />
          <Form.Control.Feedback type="invalid">Email inválido</Form.Control.Feedback>

          <Form.Label>Contraseña</Form.Label>
          <Form.Control
            required
            type="password"
            placeholder="Contraseña"
            size='lg'
            name="citizenPassword" // Agregar el nombre del input
            value={formData.citizenPassword}
            onChange={handleChange} // Manejar el cambio
          />
          <Form.Control.Feedback type="invalid">Contraseña inválida</Form.Control.Feedback>

          <div className="d-flex justify-content-center mb-4">
            <a href='/register'>Todavía no tienes una cuenta? Regístrate</a>
          </div>

          <MDBBtn type='submit' className="mb-4 w-100" size="lg">
            Ingresar
          </MDBBtn>
        </MDBCol>
      </MDBRow>
    </Form>
  );
}

export default Login;
