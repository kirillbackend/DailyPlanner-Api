using Microsoft.Extensions.Logging;

namespace DailyPlanner.Services.Facades
{
    public abstract class AbstractFacade
    {
        public ILogger Logger { get; }

        public AbstractFacade(ILogger logger)
        {
            Logger = logger;
        }
    }
}
