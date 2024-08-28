﻿using DailyPlanner.Data.Contracts;
using DailyPlanner.Data.Repositories.Contracts;
using DailyPlanner.Service;
using DailyPlanner.Services.Contracts;
using DailyPlanner.Services.Dtos;
using DailyPlanner.Services.Mappers.Contracts;
using Microsoft.Extensions.Logging;

namespace DailyPlanner.Services
{
    public class AuthService : AbstractService, IAuthService
    {

        public AuthService(ILogger<AuthService> logger, IMapperFactory mapperFactory
            , IDailyPlannerDataContextManager dataContextManager)
            : base(logger, mapperFactory, dataContextManager)
        {
        }

        public async Task SignUp(UserDto signUpDto)
        {
            Logger.LogInformation("AuthService.SignUp started");

            var repo = DataContextManager.CreateRepository<IUserRepository>();
            var signUpMapper = MapperFactory.GetMapper<IUserMapper>();

            var user = signUpMapper.MapFromDto(signUpDto);

            repo.Add(user);

            Logger.LogInformation("AuthService.SignUp completed");
        }
    }
}
