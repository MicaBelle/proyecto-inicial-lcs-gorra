import { HttpMethods, findHttpMethod } from "./HttpMethods";

const validateEndpoint = (endpoint) => {
    if (typeof endpoint !== 'string' || !endpoint.trim()) {
        throw new Error('La URL del endpoint es inválida');
    }
};

const validateMethod = (method) => {
    const httpMethod = findHttpMethod(method);
    if (!httpMethod) {
        throw new Error('Método HTTP inválido');
    }
    return httpMethod;
};

const getFetchOptions = (method, data) => {
    const options = {
        method: method,
        headers: {
        'Content-Type': 'application/json',
        },
    };

    if (data && (method === HttpMethods.POST || method === HttpMethods.PUT || method === HttpMethods.PATCH)) {
        options.body = JSON.stringify(data);
    }

    return options;
};

const handleResponse = async (response) => {
    if (!response.ok) {
        throw new Error(`Error en la solicitud: ${response.statusText}`);
    }
    return await response.json();
};

/*
Ejemplo de ejecución: 
executeFetch('https://api.example.com/1', { key: 'value' }, HttpMethods.POST)
.then(data => console.log(data))
.catch(error => console.error(error));
*/
export const executeFetch = async (endpoint, data = null, method) => {
    try {
        validateEndpoint(endpoint);
        const httpMethod = validateMethod(method);

        const options = getFetchOptions(httpMethod, data);

        const response = await fetch(endpoint, options);

        return await handleResponse(response);
    } catch (error) {
        console.error('Error en la solicitud:', error);
        throw error;
    }
};