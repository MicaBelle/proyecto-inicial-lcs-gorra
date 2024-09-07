import Card from '@mui/material/Card';
import CardActions from '@mui/material/CardActions';
import CardContent from '@mui/material/CardContent';
import Button from '@mui/material/Button';
import Typography from '@mui/material/Typography';
import { MapContainer, TileLayer, Marker, Popup } from 'react-leaflet';
import 'leaflet/dist/leaflet.css'; // Importa los estilos de Leaflet
import { useNavigate } from 'react-router-dom';
import Swal from 'sweetalert2';

export default function CardReport({report}) {
  const navigate = useNavigate();

  const handleClick = (path) => {
    navigate(path);
  };

  const deleteReport = () => {
    Swal.fire({
        title: "Estas seguro/a que deseas eliminar la denuncia?",
        showDenyButton: true,
        confirmButtonColor: "#dd6b55",
        confirmButtonText: "Eliminar",
        denyButtonColor: "#aaa",
        denyButtonText: `Cancelar`
      }).then((result) => {
        if (result.isConfirmed) {
            Swal.fire({
                title: "Denuncia eliminada con éxito!",
                icon: "success",
                confirmButtonColor: "#0d6efd"
            });
        }
      });
  };

  return (
    <div className='d-flex justify-content-center'>
      <Card sx={{ maxWidth: 345 }}>
        <div style={{ height: '100px', width: '100%' }}>
          <MapContainer
            center={report.coordenadas}
            zoom={13}
            scrollWheelZoom={false}
            style={{ height: '100%', width: '100%' }}
          >
            <TileLayer
              url="https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png"
            />
            <Marker position={report.coordenadas}>
              <Popup>
                Aquí sucedio el hecho.
              </Popup>
            </Marker>
          </MapContainer>
        </div>
        
        <CardContent>
          <Typography gutterBottom variant="h5" component="div">
            Reporte del día {new Date(report.createDate).toUTCString()} en {report.location}.
          </Typography>
          <Typography variant="body2" sx={{ color: 'text.secondary' }}>
              {report.denunciaDescription}
          </Typography>
        </CardContent>
        <CardActions>
          <Button size="small" onClick={() => handleClick("/edit-report")}>Modificar</Button>
          <Button size="small" onClick={() => deleteReport()}>Eliminar</Button>
        </CardActions>
      </Card>
    </div>
  );
}
