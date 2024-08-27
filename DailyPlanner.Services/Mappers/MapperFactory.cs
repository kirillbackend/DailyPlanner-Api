using Autofac;
using DailyPlanner.Services.Mappers.Contracts;

namespace DailyPlanner.Services.Mappers
{
    public class MapperFactory : IMapperFactory
    {
        private ILifetimeScope _container;

        public static void Configure(ContainerBuilder builder)
        {
            builder.RegisterType<AuthMapper>().As<IAuthMapper>().SingleInstance();

            // self-register
            builder.RegisterType<MapperFactory>().As<IMapperFactory>().SingleInstance();
        }

        public T GetMapper<T>() where T : IMapper
        {
            return _container.Resolve<T>();
        }

        public MapperFactory(ILifetimeScope container)
        {
            _container = container;
        }
    }
}
