import { executeFetch } from "./fetch";
import { HttpMethods } from "./HttpMethods";

// Función para registrarse
export const postCitizen = async (data) => {
    const endpoint = 'https://gorraapp.miproyectodevopsmica.com/citizen';
    return await executeFetch(endpoint, data, HttpMethods.POST);
};

// Función para logear
export const postCitizenLogin = async (data) => {
    const endpoint = 'https://gorraapp.miproyectodevopsmica.com/citizen/login';
    return await executeFetch(endpoint, data, HttpMethods.POST);
};