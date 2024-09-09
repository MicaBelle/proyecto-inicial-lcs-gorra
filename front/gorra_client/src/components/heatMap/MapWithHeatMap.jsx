import React, { useEffect, useState } from 'react';
import L from 'leaflet';
import 'leaflet/dist/leaflet.css';
import 'leaflet.heat';
import GeoRef from '../../services/geoRef';
import { getDenuncia } from '../../services/denunciaService';

export default function MapWithHeatmap() {
  const [location, setLocation] = useState(null);
  const [localidades, setLocalidades] = useState(null);
  const [localidadBuscada, setLocalidadBuscada] = useState('');
  const [denunciasMostrar, setDenunciasMostrar] = useState([]);
  const [fecha, setFecha] = useState('');

  const obtenerDenuncias = async () => {
    let denuncias = await getDenuncia();
    setDenunciasMostrar(denuncias.data.denuncias)
  }

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
  }, []);

  useEffect(() => {
    if (denunciasMostrar.length === 0) {
      obtenerDenuncias();
    }
  }, [denunciasMostrar]);

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
      heatData = denunciasMostrar && denunciasMostrar.filter(d => d.createDate == fecha).map(d => [d.coordenadas[0], d.coordenadas[1], 10]);
    }else{
      heatData = denunciasMostrar && denunciasMostrar.map(d => [d.coordenadas[0], d.coordenadas[1], 10]);
    }

    L.heatLayer(heatData, { radius: 25, blur: 15,
        gradient: {
            0.0: 'yellow',
            0.5: 'orange',
            1.0: 'red'
          }
     }).addTo(map);

    return () => map.remove();
  }, [location, fecha, denunciasMostrar]);

  return (
    <div id="container-map">
      <div className='mb-1'>
      <div className="form-group">
        <label>Nombre localidad: </label>
        <input type="text" onChange={(event) => handleLocalidad(event.target.value)} className="form-control" id="nombreLocalidad"/>
      </div>
      <div className="form-group">
        <label htmlFor="exampleInputEmail1">Localidad</label>
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
      <div className="form-group">
        <label htmlFor="exampleInputPassword1">Fecha</label>
        <input type="date" className="form-control" id="fecha" value={fecha} onChange={(event) => handleFecha(event.target.value)}/>
      </div>
      </div>
      <div id="map" style={{ height: '40vh', width: '100%'}}>
      </div>
    </div>
  );
}