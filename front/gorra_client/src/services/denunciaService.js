import { executeFetch } from "./fetch";
import { HttpMethods } from "./HttpMethods";

let endpoint = 'http://54.227.167.207:8080/denuncia'

// Función para cargar una denuncia
export const postDenuncia = async (data) => {
    return await executeFetch(endpoint, data, HttpMethods.POST);
};

// Función para modificar una denuncia
export const putDenuncia = async (data) => {
    return await executeFetch(endpoint, data, HttpMethods.PUT);
};

// Función para obtener denuncias
export const getDenuncia = async (id) => {
    return await executeFetch(endpoint + '/', null, HttpMethods.GET);
};

// Función para tener denuncias por id
export const getDenunciaByIdCitizenId = async (id) => {
    return await executeFetch(endpoint + `/${id}`, null, HttpMethods.GET);
};

// Función para eliminar denuncia
export const deleteDenuncia = async (citizenId, denunciaId) => {
    return await executeFetch(endpoint + `?citizenId=${citizenId}&denunciaId=${denunciaId}`, null, HttpMethods.DELETE);
};