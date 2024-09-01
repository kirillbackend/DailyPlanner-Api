using Autofac;
using DailyPlanner.Data;
using DailyPlanner.Services;
using DailyPlanner.Localization;
using DailyPlanner.Services.Facades;
using DailyPlanner.Services.Mappers;
using DailyPlanner.Services.Contracts;
using DailyPlanner.Services.Facades.Contracts;

namespace DailyPlanner.Service
{
    public class ContainerConfiguration
    {
        public static void RegisterTypes(ContainerBuilder builder, DailyPlannerServiceSettings settings)
        {
            if (settings == null)
            {
                throw new ArgumentNullException(nameof(settings));
            }

            builder.RegisterInstance(settings);
            MapperFactory.Configure(builder);

            Data.ContainerConfiguration.RegisterTypes<DailyPlannerDataContext>(builder, settings.ConnectionStrings);
            Localization.ContainerConfiguration.RegisterTypes(builder);

            builder.RegisterType<ContextLocator>().AsSelf().InstancePerLifetimeScope();

            //register service
            builder.RegisterType<AuthService>().As<IAuthService>();
            builder.RegisterType<HashService>().As<IHashService>();
            builder.RegisterType<UserService>().As<IUserService>();

            //register facade
            builder.RegisterType<AuthFacade>().As<IAuthFacade>();
        }
    }
}
