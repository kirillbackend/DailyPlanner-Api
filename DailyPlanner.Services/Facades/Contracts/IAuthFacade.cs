using DailyPlanner.Services.Dtos;

namespace DailyPlanner.Services.Facades.Contracts
{
    public interface IAuthFacade
    {
        Task SingUp(SignUpDto singUpDto);
    }
}
