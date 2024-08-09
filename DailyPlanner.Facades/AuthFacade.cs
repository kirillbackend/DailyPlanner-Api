using DailyPlanner.Facades.Contracts;
using DailyPlanner.Services.Contracts;
using DailyPlanner.Services.Dtos;

namespace DailyPlanner.Facades
{
    public class AuthFacade : IAuthFacade
    {
        private readonly IAuthService _authSercive;

        public AuthFacade(IAuthService authSercive)
        {
            _authSercive = authSercive;
        }

        public async Task SignUp(SignUpDto signUpDto)
        {

        }
    }
}
