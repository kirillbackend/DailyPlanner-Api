using DailyPlanner.Services.Contracts;
using DailyPlanner.Services.Dtos;
using DailyPlanner.Services.Facades.Contracts;
using Microsoft.Extensions.Logging;
using DailyPlanner.Services.Exceptions;

namespace DailyPlanner.Services.Facades
{
    public class AuthFacade : AbstractFacade, IAuthFacade
    {
        private readonly IAuthService _authService;
        private readonly IHashService _hashService;
        private readonly IUserService _userService;

        public AuthFacade(ILogger<AuthFacade> logger, IAuthService authService, IHashService hashService, IUserService userService)
            : base(logger)
        {
            _authService = authService;
            _hashService = hashService;
            _userService = userService;
        }

        public async Task SingUp(SignUpDto singUpDto)
        {
            Logger.LogInformation("AuthFacade.SingUp started");

            var userDto = await _userService.GetUserByUserName(singUpDto.Username);

            if (userDto != null)
            {
                Logger.LogWarning($"AuthFacade.SingUp a user with that name has already been registered. Username : {singUpDto.Username}");
                throw new ValidationException("User has already been registered.");
            }

            userDto = new UserDto()
            {
                Name = singUpDto.Username,
                Password = await _hashService.CreateHashPassword(singUpDto.Password)
            };

            await _authService.SignUp(userDto);

            Logger.LogInformation("AuthFacade.SingUp completed");
        }


        public async Task Login(LoginDto loginDto)
        {
            Logger.LogInformation("AuthFacade.Login started");


            Logger.LogInformation("AuthFacade.Login completed");
        }
    }
}
