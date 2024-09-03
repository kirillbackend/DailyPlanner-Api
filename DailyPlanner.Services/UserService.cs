using DailyPlanner.Service;
using DailyPlanner.Localization;
using DailyPlanner.Services.Dtos;
using DailyPlanner.Data.Contracts;
using DailyPlanner.Services.Contracts;
using DailyPlanner.Services.Mappers.Contracts;
using DailyPlanner.Data.Repositories.Contracts;
using Microsoft.Extensions.Logging;

namespace DailyPlanner.Services
{
    public class UserService : AbstractService, IUserService
    {
        private readonly ContextLocator _contextLocator;

        public UserService(ILogger<UserService> logger, IMapperFactory mapperFactory, ContextLocator contextLocator
            , IDataContextManager dataContextManager)
            : base(logger, mapperFactory, dataContextManager)
        {
            _contextLocator = contextLocator;
        }

        public async Task<UserDto> GetUserByUserName(string userName)
        {
            Logger.LogInformation("UserService.GetUserByUserName started");
            var resourceProvider = _contextLocator.GetContext<LocaleContext>().ResourceProvider;

            var repo = DataContextManager.CreateRepository<IUserRepository>();
            var mapper = MapperFactory.GetMapper<IUserMapper>();

            var user = await repo.GetUserByName(userName);
            var userDto = mapper.MapToDto(user);

            Logger.LogInformation("UserService.GetUserByUserName completed");
            return userDto;
        }
    }
}
