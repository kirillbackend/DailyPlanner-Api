﻿using DailyPlanner.Data.Contracts;
using DailyPlanner.Data.Repositories.Contracts;
using DailyPlanner.Service;
using DailyPlanner.Services.Contracts;
using DailyPlanner.Services.Dtos;
using DailyPlanner.Services.Mappers.Contracts;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace DailyPlanner.Services
{
    public class AuthService : AbstractService, IAuthService
    {
        private readonly DailyPlannerServiceSettings _dailyPlannerServiceSettings;

        public AuthService(ILogger<AuthService> logger, IMapperFactory mapperFactory, DailyPlannerServiceSettings dailyPlannerServiceSettings
            , IDataContextManager dataContextManager)
            : base(logger, mapperFactory, dataContextManager)
        {
            _dailyPlannerServiceSettings = dailyPlannerServiceSettings;
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

        public async Task<string> CreateToken(LoginDto loginDto)
        {
            Logger.LogInformation("AuthService.CreateToken started");

            var authClaims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, loginDto.Username)
            };

            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_dailyPlannerServiceSettings.Auth.Secret));

            var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

            var tokeOptions = new JwtSecurityToken(
                    issuer: "https://localhost:5001",
                    audience: "https://localhost:5001",
                    claims: authClaims,
                    expires: DateTime.Now.AddMinutes(_dailyPlannerServiceSettings.Auth.TokenExpireMinutes),
                    signingCredentials: signinCredentials
                );

            var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);

            Logger.LogInformation("AuthService.CreateToken completed");
            return tokenString;
        }
    }
}
