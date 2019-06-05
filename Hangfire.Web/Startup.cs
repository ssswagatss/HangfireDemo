﻿using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Hangfire.Web.Startup))]
namespace Hangfire.Web
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=316888

            //GlobalJobFilters.Filters.Add(new AutomaticRetryAttribute { Attempts = 2 });
            GlobalConfiguration.Configuration
                               .UseSqlServerStorage("DemoHangfireDB")
                               .UseColouredConsoleLogProvider();
            app.UseHangfireServer();
            app.UseHangfireDashboard("/tasks");
        }
    }
}
