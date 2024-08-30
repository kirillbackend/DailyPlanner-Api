using DailyPlanner.Service;

namespace DailyPlanner_RestApi
{
    public class ApiSettings : DailyPlannerServiceSettings
    {
        public string[] AllowedOrigins { get; set; }
    }
}
