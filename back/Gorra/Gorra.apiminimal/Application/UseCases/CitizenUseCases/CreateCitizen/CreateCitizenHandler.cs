using Gorra.apiminimal.Application.Data;
using Gorra.apiminimal.Application.DTO;
using Gorra.apiminimal.Domain.Entities;
using MediatR;

namespace Gorra.apiminimal.Application.UseCases.CitizenUseCases.CreateCitizen
{
    public class CreateCitizenHandler : IRequestHandler<CreateCitizenRequest, Result<CreateCitizenResponse>>
    {


        public async Task<Result<CreateCitizenResponse>> Handle(CreateCitizenRequest request, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(request.citizenName))
            {
                return "Ingrese un nombre de usuario";
            }

            if (string.IsNullOrEmpty(request.password))
            {
                return "Ingrese una contraseña correcta";
            }

            int indice = MockData.CitizenList.Count() + 1;
            Ciudadano newCitizen = new(indice, request.citizenName, request.password, DateTime.Now, DateTime.Now);

            if (MockData.CitizenList.ContainsKey(indice))
            {
                return $"Ciudadano {request.citizenName} ya existe";
            }
            
            MockData.CitizenList.Add(indice, newCitizen);

            CreateCitizenResponse citizen = new(newCitizen.CitizenId, request.citizenName, request.password, DateTime.Now, DateTime.Now);

            return citizen;
        }
    }
}
