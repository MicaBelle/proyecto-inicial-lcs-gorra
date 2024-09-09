import React, { useState, useEffect } from 'react';
import { MapContainer, TileLayer, Marker, Popup } from 'react-leaflet';
import 'leaflet/dist/leaflet.css';
import { Container, Row, Col, Button, Form, Card } from 'react-bootstrap';
import 'bootstrap/dist/css/bootstrap.min.css';
import LocationMarker from '../components/locationMarker/LocationMarker';
import GeoRef from '../services/geoRef';
import icon from "leaflet/dist/images/marker-icon.png";
import L from "leaflet";
import iconShadow from "leaflet/dist/images/marker-shadow.png";
import {useAuth} from "../hooks/useAuth"

let DefaultIcon = L.icon({
  iconUrl: icon,
  shadowUrl: iconShadow,
});

L.Marker.prototype.options.icon = DefaultIcon;

export default function ReportCenter() {
  useAuth()
  const [incidentDetails, setInicidentDetails] = useState('');
  const [currentLocation, setCurrentLocation] = useState(null);
  const [error, setError] = useState(null);

  useEffect(() => {
    if (navigator.geolocation) {
      navigator.geolocation.getCurrentPosition(
        (position) => {
          setCurrentLocation([position.coords.latitude, position.coords.longitude]);
        },
        (error) => {
          setError(`Error Code = ${error.code}: ${error.message}`);
        }
      );
    } else {
      setError("Geolocation is not supported by this browser.");
    }
  }, []);

  async function sendDenuncia(){
    let lat = currentLocation[0]
    let lon = currentLocation[1]
    const ubicacionActual = await GeoRef.isUbicacionEnBsAs(lat, lon)
    if(ubicacionActual){
      let localidad = await GeoRef.getUbicacionPorCoords(lat, lon)
      let denuncia = {
        idCitizen: localStorage.getItem('user').id,
        denunciaDescription: incidentDetails,
        coordenadas: currentLocation,
        location: localidad.ubicacion.departamento.nombre
      }
    }
    //enviar mensaje de error
  }

  return (
    <Container fluid className="p-3">
      <Row className="justify-content-center">
        <Col xs={12} md={8}>
          <Card>
            <Card.Header as="h1" className="text-center">Reportar robo</Card.Header>
            <Card.Body>
              {error ? (
                <p className="text-danger text-center">Debe darle permisos a la app para saber su ubicación.</p>
              ) : currentLocation ? (
                <>
                  <div style={{ height: '40vh', width: '100%'}}>
                    <MapContainer center={currentLocation} zoom={16} style={{ height: '100%', width: '100%' }}>
                      <TileLayer url="https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png" />
                      <Marker position={currentLocation}>
                        <Popup>Estás aquí</Popup>
                      </Marker>
                      <LocationMarker setLoclation={setCurrentLocation} />
                    </MapContainer>
                  </div>
                  <h3 className="mt-3">Detalles del acontecimiento</h3>
                  <Form>
                    <Form.Group controlId="incidentDetails">
                      <Form.Control as="textarea" placeholder="Describe el incidente" value = {incidentDetails}
                      onChange ={ (e) => setInicidentDetails(e.target.value)}/>
                    </Form.Group>
                    <Form.Group className='d-flex justify-content-center m-3'>
                      <Button variant="primary" onClick={sendDenuncia} block>
                        Reportar robo
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
