using Autofac;
using DailyPlanner.Data.Contracts;
using DailyPlanner.Data.Repositories;
using DailyPlanner.Data.Repositories.Contracts;
using DailyPlanner.Service;

namespace DailyPlanner.Data
{
    public class ContainerConfiguration
    {
        public static void RegisterTypes(ContainerBuilder builder, ConnectionSettings settings)
        {
            if (settings == null) throw new ArgumentNullException(nameof(settings));

            builder.RegisterInstance(settings);

            builder.RegisterType<DailyPlannerDataContextManager>().As<IDailyPlannerDataContextManager>();
            builder.RegisterType<AuthRepositories>().As<IAuthRepositories>();
        }
    }
}
