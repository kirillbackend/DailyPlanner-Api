namespace DailyPlanner.Data.Contracts
{
    public interface IDailyPlannerDataContextManager
    {
        TRepository CreateRepository<TRepository>(string id = "default")
           where TRepository : class, IRepository;
    }
}
