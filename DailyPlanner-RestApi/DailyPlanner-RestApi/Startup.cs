using Autofac.Extensions.DependencyInjection;
using Newtonsoft.Json.Converters;
using DailyPlanner.Service;
using Autofac;
using Serilog;
using DailyPlanner_RestApi.ActionFilters;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;


namespace DailyPlanner_RestApi
{
    public class Startup
    {
        private readonly string _corsPolicyName = "_Origins";
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IConfiguration _configuration;
        private ILifetimeScope _autofacContainer;

        public Startup(IConfiguration configuration, IWebHostEnvironment webHostEnvironment)
        {
            _configuration = configuration;
            _webHostEnvironment = webHostEnvironment;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            var settings = BuildOptions();

            services.AddControllers(options =>
            {
                options.Filters.Add<LocaleActionFilter>();
            })
            .AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.Converters.Add(new StringEnumConverter());
            });

            services.AddCors(options =>
            {
                options.AddPolicy(_corsPolicyName, builder =>
                {
                    builder.WithOrigins(settings.AllowedOrigins)
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .AllowCredentials();
                });
            });

            services.AddAuthentication()
            .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = "https://localhost:5001",
                    ValidAudience = "https://localhost:5001",
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(settings.Auth.Secret))
                };
            });

            services.AddCors();
            services.AddSerilog();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            //todo fix UseCustomExceptionHandler
            //app.UseCustomExceptionHandler();

            app.UseRouting();
            app.UseCors(_corsPolicyName);
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            if (app is not null)
            {
                _autofacContainer = app.ApplicationServices.GetAutofacRoot();
            }

            loggerFactory.AddSerilog();
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            var settings = BuildOptions();
            ContainerConfiguration.RegisterTypes(builder, settings);

            // register filters
            builder.RegisterType<LocaleActionFilter>().AsSelf();
        }

        #region private metods

        private ApiSettings BuildOptions()
        {
            return _configuration.Get<ApiSettings>();
        }

        #endregion
    }
}
