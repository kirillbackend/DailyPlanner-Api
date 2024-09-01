using DailyPlanner.Services.Contracts;
using DailyPlanner.Services.Dtos;
using DailyPlanner.Services.Facades.Contracts;
using Microsoft.Extensions.Logging;
using DailyPlanner.Services.Exceptions;
using DailyPlanner.Localization;

namespace DailyPlanner.Services.Facades
{
    public class AuthFacade : AbstractFacade, IAuthFacade
    {
        private readonly IAuthService _authService;
        private readonly IHashService _hashService;
        private readonly IUserService _userService;
        private readonly ContextLocator _contextLocator;

        public AuthFacade(ILogger<AuthFacade> logger, IAuthService authService, IHashService hashService, IUserService userService
            , ContextLocator contextLocator)
            : base(logger)
        {
            _authService = authService;
            _hashService = hashService;
            _userService = userService;
            _contextLocator = contextLocator;
        }

        public async Task SingUp(SignUpDto singUpDto)
        {
            Logger.LogInformation("AuthFacade.SingUp started");

            var resourceProvider = _contextLocator.GetContext<LocaleContext>().ResourceProvider;
            var userDto = await _userService.GetUserByUserName(singUpDto.Username);

            if (userDto != null)
            {
                Logger.LogWarning($"AuthFacade.SingUp a user with that name has already been registered. Username : {singUpDto.Username}");
                throw new ValidationException("User has already been registered.", resourceProvider.Get("UserRegistered"));
            }

            userDto = new UserDto()
            {
                Name = singUpDto.Username,
                Password = await _hashService.CreateHashPassword(singUpDto.Password)
            };

            await _authService.SignUp(userDto);

            Logger.LogInformation("AuthFacade.SingUp completed");
        }


        public async Task<string> LogIn(LoginDto loginDto)
        {
            Logger.LogInformation("AuthFacade.LogIn started");

            var resourceProvider = _contextLocator.GetContext<LocaleContext>().ResourceProvider;
            var userDto = await _userService.GetUserByUserName(loginDto.Username);

            if (userDto == null)
            {
                Logger.LogWarning($"AuthFacade.SingUp a user with that name has already been registered. Username : {loginDto.Username}");
                throw new ValidationException("User was not found.", resourceProvider.Get("UserWasNotFound"));
            }

            var isCorretPassWord = await _hashService.VerifyHashedPassword(userDto.Password, loginDto.Password);

            if (!isCorretPassWord)
            {
                Logger.LogWarning("AuthFacade.LogIn completed. Invalid password");
                throw new ValidationException("Invalid password", resourceProvider.Get("InvalidPassword"));
            }

            var token = await _authService.CreateToken(loginDto);

            Logger.LogInformation("AuthFacade.LogIn completed");
            return token;
        }
    }
}
