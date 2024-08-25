import Container from 'react-bootstrap/Container';
import Row from 'react-bootstrap/Row';
import Col from 'react-bootstrap/Col';
import { Button, Image } from 'react-bootstrap';

export default function Home(){
    return (
        <Container fluid>
        <Row>
          <Col>
            <h1>Ayudanos a cuidarte</h1>
            <p>Una cosa es ser policia, otra es ponerse la gorra.</p>
            <Button variant="outline-light">Reportar robo</Button>
        </Col>
        <Col>
            <img src="/assets/poli.png" alt="asd" />
            <Image src='../assets/poli.png' fluid />
        </Col>
        </Row>
      </Container>
    )
}