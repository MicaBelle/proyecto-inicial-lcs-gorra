using Gorra.apiminimal.Application.Data;
using Gorra.apiminimal.Application.DTO;
using Gorra.apiminimal.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

namespace Gorra.apiminimal.Application.UseCases.CitizenUseCases.CreateCitizen
{
    public class CreateCitizenHandler : IRequestHandler<CreateCitizenRequest, Result<CreateCitizenResponse>>
    {
        private readonly IGorraDbContex _context;

        public CreateCitizenHandler(IGorraDbContex context) { 
        
            _context = context;
        }

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
            
            Ciudadano newCitizen = new(request.citizenName, request.password, DateTime.Now, DateTime.Now);

            var existCitizen = await _context.Ciudadanos.FirstOrDefaultAsync(x => x.CitizenName == request.citizenName);

            if (existCitizen != null)
            {
                return $"Ciudadano {request.citizenName} ya existe";
            }
            
            await _context.Ciudadanos.AddAsync(newCitizen);

            await _context.SaveChangesAsync(cancellationToken);

            CreateCitizenResponse citizen = new(newCitizen.CitizenId, request.citizenName, request.password, DateTime.Now, DateTime.Now);

            return citizen;
        }
    }
}
