import { executeFetch } from "./fetch";
import { HttpMethods } from "./HttpMethods";

class GeoRef {
    static async getLocationForCoords(lat, lon) {
        const url = `https://apis.datos.gob.ar/georef/api/ubicacion?lat=${lat}&lon=${lon}`;
        return await executeFetch(url, { key: 'value' }, HttpMethods.GET);
    }
}

export default GeoRef;
