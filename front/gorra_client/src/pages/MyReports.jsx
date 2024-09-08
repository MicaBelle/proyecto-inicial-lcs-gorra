import { useEffect, useState } from "react";
import CardReport from "../components/cardReport/cardReport";
import Grid from '@mui/material/Grid';
import { getDenunciaByIdCitizenId } from '../services/denunciaService.js'
import { useAuth } from "../hooks/useAuth.jsx";
        
export default function MyReports(){
    useAuth()
    const [reports, setReports] = useState([]);

    useEffect(() => {
      async function getDenuncias() {
        try {
          const response = await getDenunciaByIdCitizenId(1);
          setReports(response.data.denuncia || []);
          console.log(response.data.denuncia)
        } catch (error) {
          console.error("Error fetching reports:", error);
        }
      }
      getDenuncias(); // Llamar a la función asíncrona
    }, []);

    return(
        <div>
          <Grid container spacing={2}>
            {reports.map(report => (
              <Grid item xs={12} sm={6} md={4} key={report.idCitizen}>
                <CardReport report={report} />
              </Grid>
            ))}
          </Grid>
        </div>
        
    );
}