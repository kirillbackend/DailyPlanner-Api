using DailyPlanner.Service;

namespace DailyPlanner_RestApi
{
    public class ApiSettings : DailyPlannerServiceSettings
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
