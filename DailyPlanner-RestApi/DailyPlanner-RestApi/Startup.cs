using Autofac.Extensions.DependencyInjection;
using Newtonsoft.Json.Converters;
using Autofac;
using Serilog;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using DailyPlanner_RestApi.Middlewares;
using DailyPlanner.Service;


namespace DailyPlanner_RestApi
{
    public class Startup
    {
        private readonly string _corsPolicyName = "_Origins";
        public IConfiguration Configuration { get; private set; }
        public ILifetimeScope AutofacContainer { get; private set; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            var settings = BuildOptions();

            services.AddControllers(options =>
            {
                //todo: add action filters
                //settings.Filters.Add<LocaleActionFilter>();

                //settings.Filters.Add<OrganizationActionFilter>();
            })
            .AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.Converters.Add(new StringEnumConverter());
            });

            //services.AddCors(options =>
            //{
            //    options.AddPolicy(_corsPolicyName, builder =>
            //    {
            //        builder.WithOrigins(settings.AllowedOrigins)
            //            .AllowAnyMethod()
            //            .AllowAnyHeader()
            //            .AllowCredentials();
            //    });
            //});

            //services.AddAuthentication()
            //.AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
            //{
            //    options.TokenValidationParameters = new TokenValidationParameters
            //    {
            //        ValidateIssuer = true,
            //        ValidateAudience = true,
            //        ValidateLifetime = true,
            //        ValidateIssuerSigningKey = true,
            //        ValidIssuer = "https://localhost:5001",
            //        ValidAudience = "https://localhost:5001",
            //        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(settings.Auth.Secret))
            //    };
            //});

            services.AddSerilog();
            services.AddCors();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            app.UseCustomExceptionHandler();

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
                AutofacContainer = app.ApplicationServices.GetAutofacRoot();
            }

            loggerFactory.AddSerilog();
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            var settings = BuildOptions();
            ContainerConfiguration.RegisterTypes(builder, settings);


            //todo add action filters
            // register filters
            //builder.RegisterType<OrganizationActionFilter>().AsSelf();
            //builder.RegisterType<ExceptionHandler>().AsSelf();
        }

        #region private metods

        private ApiSettings BuildOptions()
        {
            return Configuration.Get<ApiSettings>();
        }

        #endregion
    }
}
