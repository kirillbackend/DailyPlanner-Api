using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using DailyPlanner.Model;
using DailyPlanner.Service;

namespace DailyPlanner.Data
{
    public class DailyPlannerDataContext : DbContext
    {
        protected readonly IConfiguration Configuration;
        private readonly ConnectionSettings _settings;

        public DailyPlannerDataContext(DbContextOptions<DailyPlannerDataContext> options, IConfiguration configuration, ConnectionSettings settings)
            : base(options)
        {
            _settings = settings;
            Configuration = configuration;
        }

        public DailyPlannerDataContext(ConnectionSettings settings)
        {
            _settings = settings;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(Configuration.GetConnectionString(_settings.MSSQLDatabase));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SignUpModel>(builder =>
            {
                builder.ToTable("SignUpModel");
            });
        }

        public DbSet<SignUpModel> SignUpModels { get; set; }
    }
}
