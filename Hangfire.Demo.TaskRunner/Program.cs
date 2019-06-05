using Serilog;
using Topshelf;

namespace Hangfire.Demo.TaskRunner
{
    class Program
    {
        static void Main(string[] args)
        {
            //Configure Serilog
            Log.Logger = new LoggerConfiguration()
                         .WriteTo.ColoredConsole()
                         .WriteTo.File(@"C:\Logs\HfDemo\logfile.log")
                         .CreateLogger();

            //Configure Hangfire Storage
            GlobalJobFilters.Filters.Add(new AutomaticRetryAttribute { Attempts = 2 });
            GlobalJobFilters.Filters.Add(new LogEverythingAttribute());
            GlobalConfiguration.Configuration.UseSqlServerStorage("DemoHangfireDB");

            //Configure TopShelf
            HostFactory.Run(x =>
            {
                x.UseSerilog();

                x.Service<BackgroundTaskRunnerService>(s =>
                {
                    s.ConstructUsing(tr => new BackgroundTaskRunnerService());
                    s.WhenStarted(tr => tr.Start());
                    s.WhenStopped(tr => tr.Stop());
                });

                x.RunAsLocalSystem();

                x.SetDescription("Background TaskRunner Service");
                x.SetDisplayName("BackgroundTaskRunnerService");
                x.SetServiceName("BackgroundTaskRunnerService");
            });
        }
    }
}
