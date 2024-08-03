using Autofac.Core;
using Autofac;
using static System.Runtime.InteropServices.JavaScript.JSType;

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
            //builder.RegisterType<ValidatorFactory>().As<IValidatorFactory>();

            //Data.ContainerConfiguration.RegisterTypes<CalendarDataContext>(builder, settings.DominoConnection);
            //Localization.ContainerConfiguration.RegisterTypes(builder);
            //Services.Common.ContainerConfiguration.RegisterTypes(builder);

            //builder.RegisterType<ContextLocator>().AsSelf().InstancePerLifetimeScope();
            //CalendarMapperFactory.Configure(builder);

            //builder.RegisterType<AppointmentFacade>().As<IAppointmentFacade>();
        }
    }
}
