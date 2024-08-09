using Microsoft.Extensions.Logging;

namespace DailyPlanner.Facades
{
    public class AbstractFacade 
    {
        public ILogger Logger { get; }

        public AbstractFacade(ILogger logger)
        {
            Logger = logger;
        }
    }
}
