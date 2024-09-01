using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using DailyPlanner.Model;
using DailyPlanner.Service;
using System.Reflection;

namespace DailyPlanner.Data
{
    public class DailyPlannerDataContext : DbContext
    {
        protected readonly IConfiguration Configuration;
        private readonly ConnectionSettings _settings;

        public DailyPlannerDataContext(IConfiguration configuration, ConnectionSettings settings)
        {
            Configuration = configuration;
            _settings = settings;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(Configuration.GetConnectionString("ConnectionString"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public DbSet<User> Users { get; set; }
    }
}
