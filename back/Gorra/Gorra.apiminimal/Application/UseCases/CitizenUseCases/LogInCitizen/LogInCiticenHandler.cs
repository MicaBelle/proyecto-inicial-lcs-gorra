using Gorra.apiminimal.Application.Data;
using Gorra.apiminimal.Application.DTO;
using MediatR;

namespace Gorra.apiminimal.Application.UseCases.CitizenUseCases.LogInCitizen
{
    public class LogInCiticenHandler : IRequestHandler<LogInCitizenRequest, Result>
    {
        public async Task<Result> Handle(LogInCitizenRequest request, CancellationToken cancellationToken)
        {

           var login =  MockData.CitizenList.FirstOrDefault(x => x.Value.CitizenName == request.citizenUserName && x.Value.CitizenPass == request.citizenPassword);

            if(login.Value != null)
            {
                return true;
            }

            return false;
        }
    }
}
