import CardReport from "../components/cardReport/cardReport";
import Grid from '@mui/material/Grid';

export default function MyReports(){
    //formato en como trae las denuncias.
    /*let denuncia = {
      idDenuncia,
      idCitizen,
      denunciaDescription,
      coordenadas,
      modificationDate,
      createDate,
      location
    }*/

      /*let denuncia = {
        idDenuncia,
        coordenadas,
        denunciaDescription,
        createDate,
        location
      }*/

    const reports = [
        {
          id: 1,
          date: "14 Jun 2019",
          coordenada: [-34.49, -58.68],
          lugar: "Villa de Mayo",
          detalle: "Aca se robaron algo amigo."
        },
        {
          id: 2,
          date: "22 Jul 2019",
          coordenada: [-34.64, -58.56],
          lugar: "San Isidro",
          detalle: "Incidente de tránsito en la zona céntrica."
        },
        {
          id: 3,
          date: "05 Aug 2019",
          coordenada: [-34.77, -58.39],
          lugar: "La Plata",
          detalle: "Inundación en barrios cercanos al río."
        },
        {
          id: 4,
          date: "15 Sep 2019",
          coordenada: [-34.61, -58.38],
          lugar: "Avellaneda",
          detalle: "Corte de luz en toda la zona."
        },
        {
          id: 5,
          date: "03 Oct 2019",
          coordenada: [-34.90, -58.04],
          lugar: "San Nicolás",
          detalle: "Manifestación en la plaza principal."
        },
        {
          id: 6,
          date: "18 Nov 2019",
          coordenada: [-34.70, -58.32],
          lugar: "Quilmes",
          detalle: "Problemas en el suministro de agua potable."
        },
        {
          id: 7,
          date: "28 Dec 2019",
          coordenada: [-34.73, -58.25],
          lugar: "Lomas de Zamora",
          detalle: "Accidente vehicular en la avenida principal."
        },
        {
          id: 8,
          date: "10 Jan 2020",
          coordenada: [-34.58, -58.47],
          lugar: "Tigre",
          detalle: "Desborde del río en zonas bajas."
        },
        {
          id: 9,
          date: "20 Feb 2020",
          coordenada: [-34.60, -58.50],
          lugar: "San Fernando",
          detalle: "Robo en una casa de la periferia."
        },
        {
          id: 10,
          date: "05 Mar 2020",
          coordenada: [-34.90, -57.92],
          lugar: "Ensenada",
          detalle: "Protesta de vecinos por inseguridad."
        }
      ];

    return(
        <div>
          <Grid container spacing={2}>
            {reports.map(report => (
              <Grid item xs={12} sm={6} md={4} key={report.id}>
                <CardReport report={report} />
              </Grid>
            ))}
          </Grid>
        </div>
        
    );
}