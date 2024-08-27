using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using DailyPlanner.Model;
using DailyPlanner.Service;
using DailyPlanner.Data.Mapping;
using System.Reflection;

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

            modelBuilder.ApplyConfiguration(new SignUpModelMap());
            modelBuilder.ApplyConfiguration(new SignUpModelMap());


            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DailyPlannerDataContext).Assembly);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public DbSet<SignUpModel> SignUpModels { get; set; }
    }
}
