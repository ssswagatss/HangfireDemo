using Microsoft.Owin;
using Owin;
using Serilog;

[assembly: OwinStartup(typeof(Hangfire.Web.Startup))]
namespace Hangfire.Web
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=316888

            //Log.Logger = new LoggerConfiguration()
            //                        .WriteTo.File(@"C:\Logs\HfDemo\logfile.log", rollingInterval: RollingInterval.Day)
            //                        .CreateLogger();
            GlobalJobFilters.Filters.Add(new AutomaticRetryAttribute { Attempts = 2 });
            GlobalConfiguration.Configuration
                               .UseSqlServerStorage("DemoHangfireDB");
                               //.UseSerilogLogProvider();
            app.UseHangfireServer();
            app.UseHangfireDashboard("/tasks");
        }
    }
}
