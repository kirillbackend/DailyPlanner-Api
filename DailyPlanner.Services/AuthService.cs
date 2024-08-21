using DailyPlanner.Service;
using DailyPlanner.Services.Contracts;
using Microsoft.Extensions.Logging;

namespace DailyPlanner.Services
{
    public class AuthService : AbstractService, IAuthService
    {
        public AuthService(ILogger<AuthService> logger)
            : base(logger)
        {
        }
    }
}
