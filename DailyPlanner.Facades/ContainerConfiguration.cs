using Autofac;
using DailyPlanner.Facades.Contracts;

namespace DailyPlanner.Facades
{
    public class ContainerConfiguration
    {
        public static void RegisterTypes(ContainerBuilder builder, DailyPlannerFacadeSettings settings)
        {
            if (settings == null)
            {
                throw new ArgumentNullException(nameof(settings));
            }

            builder.RegisterInstance(settings);

            Service.ContainerConfiguration.RegisterTypes(builder, settings);

            builder.RegisterType<AuthFacade>().As<IAuthFacade>();
        }
    }
}
