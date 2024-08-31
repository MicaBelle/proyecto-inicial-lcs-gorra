import Card from '@mui/material/Card';
import CardActions from '@mui/material/CardActions';
import CardContent from '@mui/material/CardContent';
import Button from '@mui/material/Button';
import Typography from '@mui/material/Typography';
import { MapContainer, TileLayer, Marker, Popup } from 'react-leaflet';
import 'leaflet/dist/leaflet.css'; // Importa los estilos de Leaflet

export default function CardReport({report}) {

  return (
    
    <Card sx={{ maxWidth: 345 }}>
      <div style={{ height: '100px', width: '100%' }}>
        <MapContainer
          center={report.coordenada}
          zoom={13}
          scrollWheelZoom={false}
          style={{ height: '100%', width: '100%' }}
        >
          <TileLayer
            url="https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png"
          />
          <Marker position={report.coordenada}>
            <Popup>
              Aquí sucedio el hecho.
            </Popup>
          </Marker>
        </MapContainer>
      </div>
      
      <CardContent>
        <Typography gutterBottom variant="h5" component="div">
          Reporte del día {new Date(report.date).toUTCString()} en {report.lugar}.
        </Typography>
        <Typography variant="body2" sx={{ color: 'text.secondary' }}>
            {report.detalle}
        </Typography>
      </CardContent>
      <CardActions>
        <Button size="small">Modificar</Button>
        <Button size="small">Eliminar</Button>
      </CardActions>
    </Card>
  );
}
