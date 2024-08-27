using DailyPlanner.Data.Contracts;
using DailyPlanner.Data.Repositories.Contracts;
using DailyPlanner.Model;
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
            Logger.LogInformation("AuthService.SignUp started");

            var repo = DataContextManager.CreateRepository<IAuthRepositories>();
            var signUpMapper = MapperFactory.GetMapper<IAuthMapper>();

            var signUpModel = new SignUpModel()
            {
                Username = signUpDto.Username,
                Password = signUpDto.Password
            };
            repo.Add(signUpModel);

            Logger.LogInformation("AuthService.SignUp completed");
        }
    }
}
