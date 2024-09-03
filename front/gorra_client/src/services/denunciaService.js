import { HttpMethods } from "./HttpMethods";
import { executeFetch } from "./fetchUtility";

// Función para realizar una solicitud POST
export const postDenuncia = async (data) => {
    const endpoint = 'http://54.227.167.207:8080/denuncia';
    return await executeFetch(endpoint, data, HttpMethods.POST);
};

// Función para realizar una solicitud PUT
export const putDenuncia = async (data) => {
    const endpoint = 'http://54.227.167.207:8080/denuncia';
    return await executeFetch(endpoint, data, HttpMethods.PUT);
};

// Función para realizar una solicitud GET
export const getDenuncia = async (id) => {
    const endpoint = 'http://54.227.167.207:8080/denuncia/';
    return await executeFetch(endpoint, null, HttpMethods.GET);
};

// Función para realizar una solicitud GET por ID
export const getDenunciaByIdCitizenId = async (id) => {
    const endpoint = `http://54.227.167.207:8080/denuncia/${id}`;
    return await executeFetch(endpoint, null, HttpMethods.GET);
};


// Función para realizar una solicitud DELETE
export const deleteDenuncia = async (citizenId, denunciaId) => {
    const endpoint = `http://54.227.167.207:8080/denuncia?citizenId=${citizenId}&denunciaId=${denunciaId}`;
    return await executeFetch(endpoint, null, HttpMethods.DELETE);
};