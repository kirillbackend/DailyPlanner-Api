using DailyPlanner.Data.Contracts;
using DailyPlanner.Model;

namespace DailyPlanner.Data.Repositories.Contracts
{
    public interface IUserRepository : IRepository
    {
       void Add(User entity);
        Task<User> GetUserByName(string name);
    }
}
