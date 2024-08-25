using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using DailyPlanner.Model;

namespace DailyPlanner.Data
{
    public class DailyPlannerDataContext : DbContext
    {
        protected readonly IConfiguration Configuration;
        private readonly DailyPlannerDataSettings _settings;

        public DailyPlannerDataContext(IConfiguration configuration, DailyPlannerDataSettings settings)
        {
            Configuration = configuration;
            _settings = settings;
        }

        public DailyPlannerDataContext(DailyPlannerDataSettings settings)
        {
            _settings = settings;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(Configuration.GetConnectionString(_settings.DailyPlannerDatabase.ConnectionString));
        }

        public DbSet<SignUpModel> SignUpModels { get; set; }
    }
}
