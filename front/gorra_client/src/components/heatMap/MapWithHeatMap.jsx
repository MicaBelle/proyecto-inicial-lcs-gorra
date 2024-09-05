import React, { useEffect, useState } from 'react';
import L from 'leaflet';
import 'leaflet/dist/leaflet.css';
import 'leaflet.heat';
import { executeFetch } from '../../services/fetch';
import { HttpMethods } from '../../services/HttpMethods';
import GeoRef from '../../services/geoRef';



export default function MapWithHeatmap() {
const data = [
  [-34.5225, -58.7352, '2024-08-01'], // Centro de San Miguel
  [-34.5275, -58.7300, '2024-08-02'], // San Miguel - Localidad 1
  [-34.5200, -58.7400, '2024-08-03'], // San Miguel - Localidad 2
  [-34.5250, -58.7450, '2024-08-04'], // San Miguel - Localidad 3
  [-34.5300, -58.7500, '2024-08-05'], // San Miguel - Localidad 4
  [-34.5150, -58.7350, '2024-08-06'], // San Miguel - Localidad 5
  [-34.5230, -58.7200, '2024-08-07'], // San Miguel - Localidad 6
  [-34.5350, -58.7250, '2024-08-08'], // San Miguel - Localidad 7
  [-34.5125, -58.7450, '2024-08-09'], // San Miguel - Localidad 8
  [-34.5280, -58.7550, '2024-08-10'] // San Miguel - Localidad 9  
];

const [location, setLocation] = useState(null);
const [localidades, setLocalidades] = useState(null);
const [localidadBuscada, setLocalidadBuscada] = useState('');
const [denunciasMostrar, setDenunciasMostrar] = useState(null);
const [fecha, setFecha] = useState('');

useEffect(() => {
  if (navigator.geolocation) {
    navigator.geolocation.getCurrentPosition(
      (position) => {
        setLocation([position.coords.latitude, position.coords.longitude]);
      }
    );
  }else{
      setLocation([-34.6037, -58.3816])
  }

  if(denunciasMostrar == null){
    //funcion provisoria para utilizar denuncias aleatorias falsas
    let denunciasAleatorias = [];

    for (let i = 0; i < 100; i++) {
      const randomIndex = Math.floor(Math.random() * data.length);
      denunciasAleatorias.push(data[randomIndex]);
    }
    setDenunciasMostrar(denunciasAleatorias)
  }
}, []);

  const debounce = (func, delay) => {
    let timeoutId;
    return (...args) => {
      if (timeoutId) clearTimeout(timeoutId);
      timeoutId = setTimeout(() => func(...args), delay);
    };
  };

  const obtenerLocalidadBuenosAires = async (nombreLocalidad) => {
    try {
      const response = await GeoRef.getLocalidadesPorNombre(nombreLocalidad)
      setLocalidades(response.localidades)
    } catch (error) {
      console.error('Error al buscar localidades:', error);
    }
  };

  const debouncedObtenerLocalidad = debounce(obtenerLocalidadBuenosAires, 300);

  function handleLocalidad(nombreLocalidad) {
    setLocalidadBuscada(nombreLocalidad)
    debouncedObtenerLocalidad(nombreLocalidad);
  }
  
  function handleLocalidadSelected(localidadCoordenadas){
    const [lat, lon] = localidadCoordenadas.split("&").map(coord => parseFloat(coord));
    setLocation([lat, lon]);
  }

  function handleFecha(fecha){
    setFecha(fecha)
  }

  const today = new Date().toISOString().split('T')[0];
  useEffect(() => {
    setFecha(today);
  }, []);

  useEffect(() => {
    const map = L.map('map', {
      center: location,
      zoom: 13
    });

    L.tileLayer('https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', {
      attribution: '&copy; <a href="https://www.openstreetmap.org/copyright">OpenStreetMap</a> contributors',
    }).addTo(map);

    let heatData;
    if(fecha != today){
      heatData = denunciasMostrar && denunciasMostrar.filter(d => d[2] == fecha).map(coord => [coord[0], coord[1], 10]);
    }else{
      heatData = denunciasMostrar && denunciasMostrar.map(coord => [coord[0], coord[1], 1]);
    }

    L.heatLayer(heatData, { radius: 25, blur: 15,
        gradient: {
            0.0: 'yellow',
            0.5: 'orange',
            1.0: 'red'
          }
     }).addTo(map);

    return () => map.remove();
  }, [location, fecha]);

  return (
    <div id="container-map">
      <div className='mb-1'>
      <div class="form-group">
        <label>Nombre localidad: </label>
        <input type="text" onChange={(event) => handleLocalidad(event.target.value)} class="form-control" id="nombreLocalidad"/>
      </div>
      <div class="form-group">
        <label for="exampleInputEmail1">Localidad</label>
        {localidades && localidades.length > 0 ? (
          <select 
            className="form-control" 
            id="localidad" 
            onChange={(event) => handleLocalidadSelected(event.target.value)}
          >
            {localidades.map((localidad) => (
              <option 
                key={localidad.nombre}
                value={localidad.centroide.lat + "&" + localidad.centroide.lon}
              >
                {localidad.nombre}
              </option>
            ))}
          </select>
        ) : (
          <select 
            className="form-control"
            disabled
          >
          </select>
        )}
      </div>
      <div class="form-group">
        <label for="exampleInputPassword1">Fecha</label>
        <input type="date" class="form-control" id="fecha" value={fecha} onChange={(event) => handleFecha(event.target.value)}/>
      </div>
      </div>
      <div id="map" style={{ height: '40vh', width: '100%'}}>
      </div>
    </div>
  );
}