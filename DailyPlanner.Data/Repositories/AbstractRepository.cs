
namespace DailyPlanner.Data.Repositories
{
    public abstract class AbstractRepository<T>
    {
        protected readonly DailyPlannerDataContext Context;

        public AbstractRepository(DailyPlannerDataContext context)
        {
            Context = context;
        }
    }
}
