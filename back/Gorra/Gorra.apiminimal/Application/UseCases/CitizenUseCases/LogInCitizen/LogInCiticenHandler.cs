using Gorra.apiminimal.Application.Data;
using Gorra.apiminimal.Application.DTO;
using MediatR;

namespace Gorra.apiminimal.Application.UseCases.CitizenUseCases.LogInCitizen
{
    public class LogInCiticenHandler : IRequestHandler<LogInCitizenRequest, Result<LogInCitizenResponse>>
    {
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

            var login =  MockData.CitizenList.FirstOrDefault(x => x.Value.CitizenName == request.citizenUserName && x.Value.CitizenPass == request.citizenPassword);

            if(login.Value != null)
            {
                return new LogInCitizenResponse(login.Key);
            }

            return "Nombre de usuario y password incorrectos";
        }
    }
}
