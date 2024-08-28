using DailyPlanner.Services.Dtos;

namespace DailyPlanner.Services.Contracts
{
    public interface IAuthService
    {
        Task SignUp(UserDto userDto);
    }
}
