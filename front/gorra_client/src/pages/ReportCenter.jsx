import React, { useState, useEffect } from 'react';
import { MapContainer, TileLayer, Marker, Popup, useMapEvents } from 'react-leaflet';
import 'leaflet/dist/leaflet.css';
import { Container, Row, Col, Button, Form } from 'react-bootstrap';
import 'bootstrap/dist/css/bootstrap.min.css';
import LocationMarker from '../components/locationMarker/LocationMarker';

export default function ReportCenter() {
  const [location, setLocation] = useState(null);
  const [error, setError] = useState(null);

  useEffect(() => {
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

  return (
    <Container fluid className="p-3">
      <h1 className="text-center">Reportar robo</h1>
      {error ? (
        <p className="text-danger text-center">Debe darle permisos a la app para saber su ubicación.</p>
      ) : location ? (
        <>
          <Row className="justify-content-center">
            <Col xs={12} md={8}>
              <div style={{ height: '200px', width: '100%' }}>
                <MapContainer center={location} zoom={13} style={{ height: '100%', width: '100%' }}>
                  <TileLayer url="https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png" />
                  <Marker position={location}>
                    <Popup>Estás aquí</Popup>
                  </Marker>
                  <LocationMarker setLocation={setLocation} />
                </MapContainer>
              </div>
            </Col>
          </Row>

          <Row className="justify-content-center mt-3">
            <Col xs={12} md={8}>
              <h3>Detalles del acontecimiento</h3>
              <Form>
                <Form.Group controlId="incidentDetails">
                  <Form.Control type="text" placeholder="Describe el incidente" />
                </Form.Group>
                <Button variant="primary" type="submit" block>
                  Reportar robo
                </Button>
              </Form>
              <p className="mt-2">Coordenadas: {location.join(', ')}</p>
            </Col>
          </Row>
        </>
      ) : (
        <p className="text-center">Obteniendo ubicación...</p>
      )}
    </Container>
  );
}
