import React, { useState } from 'react';
import {
  MDBCol,
  MDBRow,
  MDBBtn
} from 'mdb-react-ui-kit';
import newGorraLogo from "../pages/resources/gorra.png"
import { useNavigate } from 'react-router-dom';
import { Form } from 'react-bootstrap';
import { postCitizen } from '../services/citizenService';
import Swal from 'sweetalert2';

function Register() {
  const navigate = useNavigate();
  
  const [email, setEmail] = useState('');
  const [password, setPassword] = useState('');
  const [confirmPassword, setConfirmPassword] = useState('');
  const [validated, setValidated] = useState(false);

  const handleClick = (path) => {
    navigate(path);
  };

  const handleSubmit = async (event) => {
    const form = event.currentTarget;
    //SE REGISTRA A PESAR DE TIRAR ERRORES EN EL FORMULARIO
    if (form.checkValidity() === false || password !== confirmPassword) {
      event.preventDefault();
      event.stopPropagation();
    } else {
      event.preventDefault(); // Evitar la recarga de la página

      // Crear el objeto con los datos del formulario
      const userData = {
        citizenName: email,
        password: password
      };

      try {
        const response = await postCitizen(userData)

        if (response.succeeded) {
          Swal.fire({
            title: "Cuenta generada con éxito!",
            showDenyButton: false,
            confirmButtonColor: "#0d6efd",
            confirmButtonText: "  Ok"
          }).then(async(result) => {
            if (result.isConfirmed) {
              handleClick("/home");
            }
          });
        } else {
          Swal.fire({
            title: "Hubo un problema al crear la cuenta. Por favor, vuelva a intentarlo.",
            icon: "error",
            confirmButtonColor: "#0d6efd"
          })
        }
      } catch (error) {
        console.error("Error:", error);
        Swal.fire({
          title: "Hubo un problema al crear la cuenta. Por favor, vuelva a intentarlo.",
          icon: "error",
          confirmButtonColor: "#0d6efd"
        })
      }
    }

    setValidated(true);
  };

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
            type="email"
            placeholder="Email"
            size='lg'
            value={email}
            onChange={(e) => setEmail(e.target.value)}
          />
          <Form.Control.Feedback type="invalid">Email inválido</Form.Control.Feedback>

          <Form.Label>Contraseña</Form.Label>
          <Form.Control
            required
            type="password"
            placeholder="Contraseña"
            size='lg'
            value={password}
            onChange={(e) => setPassword(e.target.value)}
          />
          <Form.Control.Feedback type="invalid">Contraseña inválida</Form.Control.Feedback>

          <Form.Label>Vuelva a ingresar su contraseña:</Form.Label>
          <Form.Control
            required
            type="password"
            placeholder="Confirme su contraseña"
            size='lg'
            value={confirmPassword}
            onChange={(e) => setConfirmPassword(e.target.value)}
          />
          {password !== confirmPassword && (
            <div className="text-danger">
              Las contraseñas no coinciden.
            </div>
          )}

          <div className="d-flex justify-content-center mb-4">
            <a href="/">¿Ya tienes una cuenta? Inicia sesión</a>
          </div>

          <MDBBtn type='submit' className="mb-4 w-100" size="lg">
            Registrarme
          </MDBBtn>

        </MDBCol>

      </MDBRow>

    </Form >
  );
}

export default Register;
