using DailyPlanner.Localization.Conrtacts;

namespace DailyPlanner.Localization
{
    internal class ResourceProviderFactory : IResourceProviderFactory
    {
        public IResourceProvider CreateResourceProvider(string locale)
        {
            return new ResourceProvider(locale);
        }
    }
}
