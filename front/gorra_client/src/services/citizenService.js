import { HttpMethods } from "./HttpMethods";
import { executeFetch } from "./fetchUtility";

// Función para realizar una solicitud POST al endpoint /citizen
export const postCitizen = async (data) => {
    const endpoint = 'http://54.227.167.207:8080/citizen';
    return await executeFetch(endpoint, data, HttpMethods.POST);
};

// Función para realizar una solicitud POST al endpoint /citizen/login
export const postCitizenLogin = async (data) => {
    const endpoint = 'http://54.227.167.207:8080/citizen/login';
    return await executeFetch(endpoint, data, HttpMethods.POST);
};