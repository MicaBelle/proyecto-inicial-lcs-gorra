import { executeFetch } from "./fetch";
import { HttpMethods } from "./HttpMethods";

class GeoRef {
    static async getUbicacionPorCoords(lat, lon) {
        const url = `https://apis.datos.gob.ar/georef/api/ubicacion?lat=${lat}&lon=${lon}`;
        return await executeFetch(url, { key: 'value' }, HttpMethods.GET);
    }

    static async getLocalidadesPorNombre(nombreLocalidad){
        return await executeFetch("https://apis.datos.gob.ar/georef/api/localidades?provincia=6&nombre=" + encodeURIComponent(nombreLocalidad), null, HttpMethods.GET);
    }

    static async isUbicacionEnBsAs(lat, lon){
        const url = `https://apis.datos.gob.ar/georef/api/ubicacion?lat=${lat}&lon=${lon}`;
        const response = await executeFetch(url, { key: 'value' }, HttpMethods.GET);
        console.log(response)
        return response.ubicacion.provincia.id === "06"
    }
}

export default GeoRef;
