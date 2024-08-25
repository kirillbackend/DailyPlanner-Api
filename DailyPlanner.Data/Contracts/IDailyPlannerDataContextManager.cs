namespace DailyPlanner.Data.Contracts
{
    public interface IDailyPlannerDataContextManager
    {
        DailyPlannerDataContext Create();
    }
}
