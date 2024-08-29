using DailyPlanner.Services.Mappers.Contracts;
using Microsoft.Extensions.Logging;
using DailyPlanner.Data.Contracts;
using DailyPlanner.Localization;

namespace DailyPlanner.Service
{
    public abstract class AbstractService 
    {
        public ILogger Logger { get; }

        public IMapperFactory MapperFactory { get; }

        public IDailyPlannerDataContextManager DataContextManager { get; }

        public AbstractService(ILogger logger, IMapperFactory mapperFactory, IDailyPlannerDataContextManager dataContextManager)
        {
            Logger = logger;
            MapperFactory = mapperFactory;
            DataContextManager = dataContextManager;
        }
    }
}
