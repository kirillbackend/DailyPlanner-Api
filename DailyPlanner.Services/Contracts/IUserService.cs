
using DailyPlanner.Services.Dtos;

namespace DailyPlanner.Services.Contracts
{
    public interface IUserService
    {
        Task<UserDto> GetUserByUserName(string userName);
    }
}
