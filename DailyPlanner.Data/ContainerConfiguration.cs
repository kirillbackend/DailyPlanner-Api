using Autofac;
using DailyPlanner.Data.Contracts;
using DailyPlanner.Data.Repositories;
using DailyPlanner.Data.Repositories.Contracts;

namespace DailyPlanner.Data
{
    public class ContainerConfiguration
    {
        public static void RegisterTypes(ContainerBuilder builder, DbConnectionSettings settings)
        {
            if (settings == null) throw new ArgumentNullException(nameof(settings));

            builder.RegisterInstance(settings);

            builder.RegisterType<DataContextManager>().As<IDataContextManager>();
            builder.RegisterType<UserRepository>().As<IUserRepository>();
        }
    }
}
