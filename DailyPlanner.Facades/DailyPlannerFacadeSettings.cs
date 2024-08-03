
namespace DailyPlanner.Facades
{
    public class DailyPlannerFacadeSettings
    {
        public ConnectionSettings DailyPlannerConnection { get; set; }

    }

    public class ConnectionSettings
    {
        public string ConnectionString { get; set; }

        public string DatabaseName { get; set; }
    }
}
