using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using DailyPlanner.Model;
using System.Reflection;
using DailyPlanner.Data.Contracts;

namespace DailyPlanner.Data
{
    public class DailyPlannerDataContext : DbContext, IDataContext
    {
        protected readonly IConfiguration Configuration;
        private DbConnectionSettings _settings;
        public DbSet<User> Users { get; set; }

        public DailyPlannerDataContext(DbConnectionSettings settings)
        {
            _settings = settings;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_settings.MSSQLDatabase);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
