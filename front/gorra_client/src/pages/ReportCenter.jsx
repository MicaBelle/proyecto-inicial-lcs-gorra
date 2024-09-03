import React, { useState, useEffect } from 'react';
import { MapContainer, TileLayer, Marker, Popup } from 'react-leaflet';
import 'leaflet/dist/leaflet.css';
import { Container, Row, Col, Button, Form, Card } from 'react-bootstrap';
import 'bootstrap/dist/css/bootstrap.min.css';
import LocationMarker from '../components/locationMarker/LocationMarker';
import GeoRef from '../services/geoRef';

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

  async function executeGeoref(){
    const data = await GeoRef.getLocationForCoords(location[0], location[1]);
    console.log(data);
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
              ) : location ? (
                <>
                  <div style={{ height: '40vh', width: '100%'}}>
                    <MapContainer center={location} zoom={16} style={{ height: '100%', width: '100%' }}>
                      <TileLayer url="https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png" />
                      <Marker position={location}>
                        <Popup>Estás aquí</Popup>
                      </Marker>
                      <LocationMarker setLocation={setLocation} />
                    </MapContainer>
                  </div>
                  <h3 className="mt-3">Detalles del acontecimiento</h3>
                  <Form>
                    <Form.Group controlId="incidentDetails">
                      <Form.Control as="textarea" placeholder="Describe el incidente" />
                    </Form.Group>
                    <Form.Group className='d-flex justify-content-center m-3'>
                      <Button variant="primary" onClick={executeGeoref} block>
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
