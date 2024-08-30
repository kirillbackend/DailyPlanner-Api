using DailyPlanner.Data.Contracts;
using DailyPlanner.Data.Repositories.Contracts;
using DailyPlanner.Service;
using DailyPlanner.Services.Contracts;
using DailyPlanner.Services.Dtos;
using DailyPlanner.Services.Mappers.Contracts;
using Microsoft.Extensions.Logging;

namespace DailyPlanner.Services
{
    public class UserService : AbstractService, IUserService
    {
        public UserService(ILogger<UserService> logger, IMapperFactory mapperFactory
            , IDailyPlannerDataContextManager dataContextManager)
            : base(logger, mapperFactory, dataContextManager)
        {
        }

        public async Task<UserDto> GetUserByUserName(string userName)
        {
            Logger.LogInformation("UserService.GetUserByUserName started");

            var repo = DataContextManager.CreateRepository<IUserRepository>();
            var mapper = MapperFactory.GetMapper<IUserMapper>();

            var user = await repo.GetUserByName(userName);
            var userDto = mapper.MapToDto(user);

            Logger.LogInformation("UserService.GetUserByUserName completed");
            return userDto;
        }
    }
}
