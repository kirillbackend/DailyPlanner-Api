using DailyPlanner.Data;

namespace DailyPlanner.Service
{
    public class DailyPlannerServiceSettings
    {
        public DbConnectionSettings ConnectionStrings { get; set; }
        public JwtSettings Auth { get; set; }
    }

    public class JwtSettings
    {
        public string? Secret { get; set; }

        public int TokenExpireMinutes { get; set; }
    }
}
