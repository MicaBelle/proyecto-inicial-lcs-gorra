import React, { useState, useEffect } from 'react';
import { MapContainer, TileLayer, Marker, Popup } from 'react-leaflet';
import 'leaflet/dist/leaflet.css';
import { Container, Row, Col, Button, Form, Card } from 'react-bootstrap';
import 'bootstrap/dist/css/bootstrap.min.css';
import GeoRef from '../services/geoRef';
import { useNavigate, useLocation } from 'react-router-dom';
import Swal from 'sweetalert2'
import { putDenuncia } from '../services/denunciaService';

export default function EditReport() {
  const [userLocation, setLocation] = useState(null);
  const [description, setDescription] = useState("")
  const [error, setError] = useState(null);

  const navigate = useNavigate()
  const location = useLocation()

  const {report} = location.state

  useEffect(() => {
    setDescription(report.denunciaDescription)
    if (navigator.geolocation) {
      navigator.geolocation.getCurrentPosition(
        (position) => {
          setLocation([position.coords.latitude, position.coords.longitude]);
        },
        (error) => {
          setError(`Error Code = ${error.code}: ${error.message}`);
        }
      );
    } else {
      setError("Geolocation is not supported by this browser.");
    }
  }, []);

  async function executeGeoref(){
    const data = await GeoRef.getLocationForCoords(userLocation[0], userLocation[1]);
    console.log(data);
  }

  const handleClick = (path) => {
    navigate(path);
  };

  const updateReport = () => {
    Swal.fire({
        title: "Estas seguro/a que deseas modificar la denuncia?",
        showDenyButton: true,
        confirmButtonColor: "#0d6efd",
        confirmButtonText: "Modificar",
        denyButtonText: `Cancelar`
      }).then(async(result) => {
        if (result.isConfirmed) {
            const updateDenuncia = await putDenuncia(
              {idDenuncia: report.iddenuncia,
               idCiudadano: report.idCitizen,
               denunciaDescription: description
              })
            if(updateDenuncia.succeeded){
              Swal.fire({
                title: "Denuncia modificada con éxito!",
                icon: "success",
                confirmButtonColor: "#0d6efd"
            });
            }else{
              Swal.fire({
                title: "Ups!",
                icon: "error",
                confirmButtonColor: "#f27474"
            });
            }
        }
      });
  };

  return (
    <Container fluid className="p-3">
      <Row className="justify-content-center">
        <Col xs={12} md={8}>
          <Card>
            <Card.Header as="h1" className="text-center">Información denuncia</Card.Header>
            <Card.Body>
              {error ? (
                <p className="text-danger text-center">Debe darle permisos a la app para saber su ubicación.</p>
              ) : userLocation ? (
                <>
                  <div style={{ height: '40vh', width: '100%' }}>
                    <MapContainer center={userLocation} zoom={16} style={{ height: '100%', width: '100%' }}>
                      <TileLayer url="https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png" />
                      <Marker position={userLocation} draggable={false}>
                        <Popup>Estás aquí</Popup>
                      </Marker>
                    </MapContainer>
                  </div>
                  <h3 className="mt-3">Detalles del acontecimiento</h3>
                  <Form>
                    <Form.Group controlId="incidentDetails">
                      <Form.Control
                        as="textarea"
                        rows={5}
                        placeholder="Describe el incidente"
                        value={description}
                        onChange={(e) => setDescription(e.target.value)}
                      />
                    </Form.Group>
                    <Form.Group className='d-flex justify-content-around m-3'>
                      <Button variant="primary" onClick={() => updateReport()}>
                        Actualizar denuncia
                      </Button>
                      <Button variant="primary" onClick={() => handleClick("/my-reports")}>
                        Regresar
                      </Button>
                    </Form.Group>
                  </Form>
                </>
              ) : (
                <p className="text-center">Obteniendo ubicación...</p>
              )}
            </Card.Body>
          </Card>
        </Col>
      </Row>
    </Container>
  );
}