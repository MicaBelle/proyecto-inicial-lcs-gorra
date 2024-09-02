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
            CreateCitizenResponse citizen = new(request.citizenId,request.citizenName,request.password,DateTime.Now,DateTime.Now);

            Ciudadano newCitizen = new(request.citizenId,request.citizenName, request.password, DateTime.Now, DateTime.Now);

            if (MockData.CitizenList.ContainsKey(request.citizenId))
            {
                return $"Ciudadano {request.citizenName} ya existe";
            }
            int indice =  MockData.CitizenList.Count() + 1;
            MockData.CitizenList.Add(indice, newCitizen);

            return citizen;
        }
    }
}
