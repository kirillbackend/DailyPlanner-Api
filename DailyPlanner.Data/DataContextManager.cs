using Autofac;
using DailyPlanner.Data.Contracts;

namespace DailyPlanner.Data
{
    internal class DataContextManager : IDataContextManager
    {
        private readonly object _contextLock = new object();
        private Dictionary<string, DailyPlannerDataContext> _contexts = new Dictionary<string, DailyPlannerDataContext>();
        private DbConnectionSettings _connectionSettings;
        private readonly ILifetimeScope _container;

        public DataContextManager(ILifetimeScope container, DbConnectionSettings connectionSettings)
        {
            _container = container;
            _connectionSettings = connectionSettings;
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
                    _contexts[contextKey] = new DailyPlannerDataContext(_connectionSettings);
                }

                return _contexts[contextKey];
            }
        }

        #endregion
    }
}
