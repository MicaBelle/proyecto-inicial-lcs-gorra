import React, { useEffect } from 'react'
import { HttpMethods } from '../services/HttpMethods'
import { executeFetch } from '../services/fetch'

export default function PruebaGeoRef() {
    const printGeoRef = async() =>{
        console.log(await executeFetch("https://apis.datos.gob.ar/georef/api/ubicacion?lat=-34.519652&lon=-58.703044", null, HttpMethods.GET))
    }

    useEffect(() =>{
        printGeoRef();
    },[])

    return (
        <div></div>
    )
}
