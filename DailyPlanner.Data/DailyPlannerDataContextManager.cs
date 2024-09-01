using Autofac;
using DailyPlanner.Data.Contracts;
using DailyPlanner.Service;
using Microsoft.Extensions.Configuration;

namespace DailyPlanner.Data
{
    public class DailyPlannerDataContextManager : IDailyPlannerDataContextManager
    {
        private Dictionary<string, DailyPlannerDataContext> _contexts = new Dictionary<string, DailyPlannerDataContext>();
        private readonly object _contextLock = new object();
        private readonly ConnectionSettings _connectionSettings;
        private readonly ILifetimeScope _container;
        protected readonly IConfiguration _configuration;

        public DailyPlannerDataContextManager(ILifetimeScope container, ConnectionSettings connectionSettings, IConfiguration configuration)
        {
            _container = container;
            _connectionSettings = connectionSettings;
            _configuration = configuration;
        }

        public T CreateRepository<T>(string id = "default")
           where T : class, IRepository
        {

            return _container.Resolve<T>(new TypedParameter(typeof(DailyPlannerDataContext), GetDataContext(id)));
        }

        #region private metods

        private DailyPlannerDataContext GetDataContext(string id = "default")
        {
            var contextKey = id;

            lock (_contextLock)
            {

                if (!_contexts.ContainsKey(contextKey))
                {
                    _contexts[contextKey] = new DailyPlannerDataContext(_configuration, _connectionSettings);
                }

                return _contexts[contextKey];
            }
        }

        #endregion
    }
}
