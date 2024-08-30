using DailyPlanner.Localization.Conrtacts;

namespace DailyPlanner.Localization
{
    public class ContextFactory : IContextFactory
    {
        private IResourceProviderFactory _resourceProviderFactory;

        public ContextFactory(IResourceProviderFactory resourceProviderFactory)
        {
            _resourceProviderFactory = resourceProviderFactory;
        }

        public LocaleContext CreateLocaleContext(string locale)
        {
            return new LocaleContext(locale, _resourceProviderFactory.CreateResourceProvider(locale));
        }
    }
}
