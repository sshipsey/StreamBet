using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.Framework.ConfigurationModel;
using Microsoft.Framework.DependencyInjection;
using StreamBet.Models;

namespace StreamBet
{
    public class Startup
    {
        public static IConfiguration Configuration { get; set; }

        public Startup(IHostingEnvironment env)
        {
            // Setup configuration sources.
            Configuration = new Configuration().AddJsonFile("config.json").AddEnvironmentVariables();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            // Add EF services to the services container.
            services.AddEntityFramework().AddSqlServer().AddDbContext<StreamerDbContext>();

            services.AddMvc();

            //Resolve dependency injection
            services.AddScoped<IRegistrationRepo, RegistrationRepo>();
            services.AddScoped<StreamerDbContext, StreamerDbContext>();
        }
        public void Configure(IApplicationBuilder app)
        {
            // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
            app.UseMvc();

            app.UseWelcomePage();

        }
    }
}