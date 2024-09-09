import { useEffect, useState } from "react";
import CardReport from "../components/cardReport/cardReport";
import Grid from '@mui/material/Grid';
import { getDenunciaByIdCitizenId } from '../services/denunciaService.js'
import { useAuth } from "../hooks/useAuth.jsx";

export default function MyReports() {
    useAuth()
    const [reports, setReports] = useState([]);

    useEffect(() => {
        async function getDenuncias() {
            const id = localStorage.getItem("user");
            try {
                const response = await getDenunciaByIdCitizenId(id);
                setReports(response.data.denuncia || []);
            } catch (error) {
                console.error("Error fetching reports:", error);
            }
        }
        getDenuncias();
    }, []);

    return (
        <div>
            <Grid container spacing={2}>
                {reports.length === 0 ? (
                    <Grid container justifyContent="center" alignItems="center" style={{ minHeight: '50vh' }}>
                        <Grid item>
                            <h1 style={{ textAlign: "center" }}>No tiene denuncias realizadas.</h1>
                        </Grid>
                    </Grid>
                ) : (
                    reports.map(report => (
                        <Grid item xs={12} sm={6} md={4} key={report.idCitizen}>
                            <CardReport report={report} />
                        </Grid>
                    ))
                )}
            </Grid>
        </div>
    );
}
