namespace DailyPlanner.Data.Contracts
{
    public interface IDataContextManager
    {
        TRepository CreateRepository<TRepository>(string id = "default")
           where TRepository : class, IRepository;
    }
}
