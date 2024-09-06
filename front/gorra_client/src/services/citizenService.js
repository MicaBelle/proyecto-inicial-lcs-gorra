import { HttpMethods } from "./HttpMethods";
import { executeFetch } from "./fetchUtility";

// Función para registrarse
export const postCitizen = async (data) => {
    const endpoint = 'http://54.227.167.207:8080/citizen';
    return await executeFetch(endpoint, data, HttpMethods.POST);
};

// Función para logear
export const postCitizenLogin = async (data) => {
    const endpoint = 'http://54.227.167.207:8080/citizen/login';
    return await executeFetch(endpoint, data, HttpMethods.POST);
};