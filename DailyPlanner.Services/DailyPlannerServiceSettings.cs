
namespace DailyPlanner.Service
{
    public class DailyPlannerServiceSettings
    {
        public ConnectionSettings ConnectionStrings { get; set; }
        public JwtSettings Auth { get; set; }
    }

    public class JwtSettings
    {
        public string? Secret { get; set; }

        public int TokenExpireMinutes { get; set; }
    }
}
