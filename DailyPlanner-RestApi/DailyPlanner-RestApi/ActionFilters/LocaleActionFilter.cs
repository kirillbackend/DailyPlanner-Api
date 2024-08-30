using Autofac;
using DailyPlanner.Localization.Conrtacts;
using DailyPlanner.Localization;
using Microsoft.AspNetCore.Mvc.Filters;
using DailyPlanner_RestApi.Auth;

namespace DailyPlanner_RestApi.ActionFilters
{
    public class LocaleActionFilter : IAsyncResourceFilter
    {
        private readonly ILogger<LocaleActionFilter> _logger;
        private readonly ILifetimeScope _lifetimeScope;
        private readonly IContextFactory _contextFactory;

        public LocaleActionFilter(ILogger<LocaleActionFilter> logger,
            ILifetimeScope lifetimeScope,
            IContextFactory contextFactory)
        {
            _logger = logger;
            _lifetimeScope = lifetimeScope;
            _contextFactory = contextFactory;
        }

        public async Task OnResourceExecutionAsync(ResourceExecutingContext context, ResourceExecutionDelegate next)
        {
            _logger.LogInformation($"{context.HttpContext.User}");

            context.HttpContext.Request.Headers.TryGetValue(DailyPlannerHeaderNames.Locale, out var locale);

            _logger.LogInformation("Setting up scope");
            var contextLocator = _lifetimeScope.Resolve<ContextLocator>();
            var localeContext = _contextFactory.CreateLocaleContext(!string.IsNullOrEmpty(locale.FirstOrDefault()) ? locale.Single() : "en");
            contextLocator.AddContext(localeContext);

            await next();
        }
    }
}
