using DailyPlanner.Data.Repositories.Contracts;
using DailyPlanner.Model;
using Microsoft.EntityFrameworkCore;

namespace DailyPlanner.Data.Repositories
{
    public class UserRepository : AbstractRepository<User>, IUserRepository
    {
        public UserRepository(DailyPlannerDataContext context)
            : base(context)
        {

        }

        public void Add(User entity)
        {
            Context.Add(entity);
            Context.SaveChanges();
        }

        public async Task<User> GetUserByName(string name)
        {
            var author = await Context.Users.FirstOrDefaultAsync(a => a.Name == name);
            return author;
        }
    }
}
