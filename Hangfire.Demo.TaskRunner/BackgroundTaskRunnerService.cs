using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangfire.Demo.TaskRunner
{
    public class BackgroundTaskRunnerService
    {
        private BackgroundJobServer _server;

        public void Start()
        {
            var options = new BackgroundJobServerOptions
            {
                ServerName = string.Format("{0}", Environment.MachineName),
                WorkerCount = 30,
                Queues = new[] { "critical","emailqueue","otherjobqueue" }

            };
            _server = new BackgroundJobServer(options);
        }
        public void Stop()
        {
            _server.Dispose();
        }
    }
}
