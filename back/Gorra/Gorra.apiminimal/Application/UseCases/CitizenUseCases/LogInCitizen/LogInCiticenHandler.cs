using Gorra.apiminimal.Application.Data;
using Gorra.apiminimal.Application.DTO;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Gorra.apiminimal.Application.UseCases.CitizenUseCases.LogInCitizen
{
    public class LogInCiticenHandler : IRequestHandler<LogInCitizenRequest, Result<LogInCitizenResponse>>
    {
        private readonly IGorraDbContex _context;

        public LogInCiticenHandler(IGorraDbContex context) { 
        
            _context = context;
        }
        public async Task<Result<LogInCitizenResponse>> Handle(LogInCitizenRequest request, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(request.citizenPassword))
            {
                return "Ingrese una contraseña";
            }
            if (string.IsNullOrEmpty(request.citizenUserName))
            {
                return "Ingrese un nombre de usuario";
            }

            var login =  await _context.Ciudadanos.FirstOrDefaultAsync(x => x.CitizenName == request.citizenUserName && x.CitizenPass == request.citizenPassword);

            if(login != null)
            {
                return new LogInCitizenResponse( login.CitizenId);
            }

            return "Nombre de usuario y password incorrectos";
        }
    }
}
