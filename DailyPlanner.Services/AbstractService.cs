using DailyPlanner.Services.Mappers.Contracts;
using Microsoft.Extensions.Logging;
using DailyPlanner.Data.Contracts;

namespace DailyPlanner.Service
{
    public abstract class AbstractService 
    {
        public ILogger Logger { get; }

        public IMapperFactory MapperFactory { get; }

        public IDataContextManager DataContextManager { get; }

        public AbstractService(ILogger logger, IMapperFactory mapperFactory, IDataContextManager dataContextManager)
        {
            Logger = logger;
            MapperFactory = mapperFactory;
            DataContextManager = dataContextManager;
        }
    }
}
