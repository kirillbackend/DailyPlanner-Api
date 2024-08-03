using DailyPlanner.Facades;

namespace DailyPlanner_RestApi
{
    public class ApiSettings : DailyPlannerFacadeSettings
    {
        public string[] AllowedOrigins { get; set; }
        public JwtSettings Auth { get; set; }
    }

    public class JwtSettings
    {
        public string? Secret { get; set; }

        public int TokenExpireMinutes { get; set; }
    }
}
