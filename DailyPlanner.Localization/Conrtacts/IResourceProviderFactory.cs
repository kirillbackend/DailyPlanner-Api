
namespace DailyPlanner.Localization.Conrtacts
{
    public interface IResourceProviderFactory
    {
        IResourceProvider CreateResourceProvider(string locale);
    }
}
