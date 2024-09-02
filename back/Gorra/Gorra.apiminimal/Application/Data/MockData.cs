using System;
using System.Collections.Generic;
using Gorra.apiminimal.Domain.Entities;

namespace Gorra.apiminimal.Application.Data
{
    public static class MockData
    {
        public static Dictionary<int, Ciudadano> CitizenList { get; set; }

        public static void GenerateCitizen()
        {
            CitizenList = new Dictionary<int, Ciudadano>();

            // Crear el primer ciudadano con 10 denuncias
            var citizen1 = new Ciudadano(1,"Juan Pérez", "password123", DateTime.Now, DateTime.Now)
            {
                CitizenId = 1,
                DeclaredDenuncia = new List<Denuncia>
                {
                    new Denuncia(1, "Robo de celular", (-34.603722f, -58.381592f), "Obelisco, Buenos Aires", DateTime.Now, DateTime.Now),
                    new Denuncia(1, "Hurto en transporte público", (-34.609010f, -58.377232f), "Plaza Miserere, Buenos Aires", DateTime.Now, DateTime.Now),
                    new Denuncia(1, "Asalto a mano armada", (-34.611789f, -58.417309f), "Villa Lugano, Buenos Aires", DateTime.Now, DateTime.Now),
                    new Denuncia(1, "Vandalismo en monumento", (-34.609340f, -58.402961f), "Parque Avellaneda, Buenos Aires", DateTime.Now, DateTime.Now),
                    new Denuncia(1, "Robo de vehículo", (-34.598750f, -58.426559f), "Liniers, Buenos Aires", DateTime.Now, DateTime.Now),
                    new Denuncia(1, "Robo de bicicleta", (-34.594420f, -58.413520f), "Parque Centenario, Buenos Aires", DateTime.Now, DateTime.Now),
                    new Denuncia(1, "Fraude con tarjeta de crédito", (-34.599379f, -58.372218f), "Florida, Buenos Aires", DateTime.Now, DateTime.Now),
                    new Denuncia(1, "Acoso en espacio público", (-34.615852f, -58.433298f), "Parque Rivadavia, Buenos Aires", DateTime.Now, DateTime.Now),
                    new Denuncia(1, "Robo de cartera", (-34.599704f, -58.392272f), "San Cristóbal, Buenos Aires", DateTime.Now, DateTime.Now),
                    new Denuncia(1, "Violencia de género", (-34.620180f, -58.425404f), "Flores, Buenos Aires", DateTime.Now, DateTime.Now)
                }
            };

            // Crear el segundo ciudadano con 10 denuncias
            var citizen2 = new Ciudadano(2,"María García", "mypassword", DateTime.Now, DateTime.Now)
            {
                CitizenId = 2,
                DeclaredDenuncia = new List<Denuncia>
                {
                    new Denuncia(2, "Accidente de tránsito", (-34.608278f, -58.371217f), "Avenida 9 de Julio, Buenos Aires", DateTime.Now, DateTime.Now),
                    new Denuncia(2, "Robo en vivienda", (-34.620960f, -58.396710f), "Boedo, Buenos Aires", DateTime.Now, DateTime.Now),
                    new Denuncia(2, "Estafa telefónica", (-34.598950f, -58.373352f), "Microcentro, Buenos Aires", DateTime.Now, DateTime.Now),
                    new Denuncia(2, "Amenazas", (-34.617759f, -58.446634f), "Chacarita, Buenos Aires", DateTime.Now, DateTime.Now),
                    new Denuncia(2, "Robo de moto", (-34.598400f, -58.432759f), "Villa Urquiza, Buenos Aires", DateTime.Now, DateTime.Now),
                    new Denuncia(2, "Incendio intencional", (-34.634538f, -58.397626f), "Parque Patricios, Buenos Aires", DateTime.Now, DateTime.Now),
                    new Denuncia(2, "Extorsión", (-34.589703f, -58.403306f), "Palermo, Buenos Aires", DateTime.Now, DateTime.Now),
                    new Denuncia(2, "Abuso sexual", (-34.609900f, -58.433045f), "Caballito, Buenos Aires", DateTime.Now, DateTime.Now),
                    new Denuncia(2, "Violación de domicilio", (-34.621304f, -58.375479f), "Almagro, Buenos Aires", DateTime.Now, DateTime.Now),
                    new Denuncia(2, "Homicidio", (-34.603836f, -58.382788f), "Tribunales, Buenos Aires", DateTime.Now, DateTime.Now)
                }
            };

            // Agregar los ciudadanos al diccionario
            CitizenList.Add(citizen1.CitizenId, citizen1);
            CitizenList.Add(citizen2.CitizenId, citizen2);
        }
    }
}
