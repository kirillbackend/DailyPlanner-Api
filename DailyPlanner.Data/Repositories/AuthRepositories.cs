using DailyPlanner.Data.Repositories.Contracts;
using DailyPlanner.Model;

namespace DailyPlanner.Data.Repositories
{
    public class AuthRepositories : AbstractRepository<SignUpModel>, IAuthRepositories
    {
        public AuthRepositories(DailyPlannerDataContext context)
            : base(context)
        {

        }

        public void Add(SignUpModel entity)
        {
            Context.Add(entity);
            Context.SaveChanges();
        }
    }
}
