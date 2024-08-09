using DailyPlanner.Services.Mappers.Contracts;
using Microsoft.Extensions.Logging;

namespace DailyPlanner.Service
{
    public class AbstractService 
    {
        public ILogger Logger { get; }

        public IMapperFactory MapperFactory { get; }

        public AbstractService(ILogger logger)
        {
            Logger = logger;
        }
    }
}
