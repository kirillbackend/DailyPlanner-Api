using Autofac;
using DailyPlanner.Localization.Conrtacts;

namespace DailyPlanner.Localization
{
    public class ContainerConfiguration
    {
        public static void RegisterTypes(ContainerBuilder builder)
        {
            builder.RegisterType<ResourceProviderFactory>().As<IResourceProviderFactory>();
        }
    }
}
