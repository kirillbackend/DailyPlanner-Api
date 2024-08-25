using Autofac;
using DailyPlanner.Data.Contracts;

namespace DailyPlanner.Data
{
    public class ContainerConfiguration
    {
        public static void RegisterTypes(ContainerBuilder builder, DailyPlannerDataSettings settings)
        {
            if (settings == null)
            {
                throw new ArgumentNullException(nameof(settings));
            }

            builder.RegisterInstance(settings);

            builder.RegisterType<DailyPlannerDataContextManager>().As<IDailyPlannerDataContextManager>();
        }
    }
}
