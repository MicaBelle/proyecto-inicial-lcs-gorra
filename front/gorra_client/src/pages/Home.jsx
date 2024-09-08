import Container from 'react-bootstrap/Container';
import Row from 'react-bootstrap/Row';
import Col from 'react-bootstrap/Col';
import { Button, Card, Image } from 'react-bootstrap';
import MapWithHeatmap from '../components/heatMap/MapWithHeatMap';
import { useAuth } from '../hooks/useAuth';


export default function Home(){
    useAuth()
    return (
      <Container fluid className="py-1">
      <Row className="justify-content-center text-center mb-1">
        <Col md={8}>
          <h1 className="display-4 font-weight-bold mb-1">Ayúdanos a cuidarte</h1>
          <p className="lead text-muted mb-4">Juntos, podemos prevenir el crimen y proteger a quienes más queremos. ¡Tu reporte cuenta!</p>
        </Col>
      </Row>
      <Row>
        <Col>
          <Card className="shadow-sm">
            <Card.Body>
              <MapWithHeatmap />
            </Card.Body>
          </Card>
        </Col>
      </Row>
    </Container>
    )
}