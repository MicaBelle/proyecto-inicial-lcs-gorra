import { HttpMethods } from "./HttpMethods";
import { executeFetch } from "./fetchUtility";

let endpoint = 'http://54.227.167.207:8080/denuncia'

// Función para realizar una solicitud POST
export const postDenuncia = async (data) => {
    return await executeFetch(endpoint, data, HttpMethods.POST);
};

// Función para realizar una solicitud PUT
export const putDenuncia = async (data) => {
    return await executeFetch(endpoint, data, HttpMethods.PUT);
};

// Función para realizar una solicitud GET
export const getDenuncia = async (id) => {
    return await executeFetch(endpoint + '/', null, HttpMethods.GET);
};

// Función para realizar una solicitud GET por ID
export const getDenunciaByIdCitizenId = async (id) => {
    return await executeFetch(endpoint + `/${id}`, null, HttpMethods.GET);
};

// Función para realizar una solicitud DELETE
export const deleteDenuncia = async (citizenId, denunciaId) => {
    return await executeFetch(endpoint + `?citizenId=${citizenId}&denunciaId=${denunciaId}`, null, HttpMethods.DELETE);
};