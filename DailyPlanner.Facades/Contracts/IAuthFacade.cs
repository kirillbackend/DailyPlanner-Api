using DailyPlanner.Services.Dtos;

namespace DailyPlanner.Facades.Contracts
{
    public interface IAuthFacade
    {
        Task SignUp(SignUpDto signUpDto);
    }
}
