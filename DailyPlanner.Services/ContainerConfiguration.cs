using Autofac;
using DailyPlanner.Services;
using DailyPlanner.Services.Contracts;
using DailyPlanner.Services.Mappers;


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


           builder.RegisterType<AuthService>().As<IAuthService>();

            Data.ContainerConfiguration.RegisterTypes(builder, settings.ConnectionStrings);
        }
    }
}
