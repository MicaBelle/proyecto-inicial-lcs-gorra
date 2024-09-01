using Gorra.apiminimal.Application.DTO;
using MediatR;

namespace Gorra.apiminimal.Application.UseCases.CitizenUseCases.CreateCitizen
{
    public class CreateCitizenHandler : IRequestHandler<CreateCitizenRequest, Result<CreateCitizenResponse>>
    {
        public async Task<Result<CreateCitizenResponse>> Handle(CreateCitizenRequest request, CancellationToken cancellationToken)
        {
            CreateCitizenResponse citizen = new(request.citizenId,request.citizenName,
                request.citizenLocation,true,request.citizenLat,request.citizenLong,request.location,DateTime.Now,DateTime.Now);


            return "ciudadano creado satisfactoriamente";
        }
    }
}
