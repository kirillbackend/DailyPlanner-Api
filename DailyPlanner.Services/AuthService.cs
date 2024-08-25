using DailyPlanner.Data.Contracts;
using DailyPlanner.Service;
using DailyPlanner.Services.Contracts;
using DailyPlanner.Services.Dtos;
using DailyPlanner.Services.Mappers.Contracts;
using Microsoft.Extensions.Logging;

namespace DailyPlanner.Services
{
    public class AuthService : AbstractService, IAuthService
    {
        public AuthService(ILogger<AuthService> logger, IMapperFactory mapperFactory, IDailyPlannerDataContextManager dataContextManager)
            : base(logger, mapperFactory, dataContextManager)
        {
        }

        public async Task SignUp(SignUpDto signUpDto)
        {

        }
    }
}
