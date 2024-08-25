using DailyPlanner.Data.Contracts;

namespace DailyPlanner.Data
{
    public class DailyPlannerDataContextManager : IDailyPlannerDataContextManager
    {
        private readonly DailyPlannerDataSettings _dataSettings;

        public DailyPlannerDataContextManager(DailyPlannerDataSettings dataSettings)
        {
            _dataSettings = dataSettings;
        }

        public DailyPlannerDataContext Create()
        {
            return new DailyPlannerDataContext(_dataSettings);
        }
    }
}
