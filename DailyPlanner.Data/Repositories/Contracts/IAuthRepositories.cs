
using DailyPlanner.Data.Contracts;
using DailyPlanner.Model;

namespace DailyPlanner.Data.Repositories.Contracts
{
    public interface IAuthRepositories : IRepository
    {
       void Add(SignUpModel entity);
    }
}
