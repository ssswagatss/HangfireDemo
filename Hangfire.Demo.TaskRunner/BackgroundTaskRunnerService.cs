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
            //var options = new BackgroundJobServerOptions
            //{
            //    ServerName = string.Format("{0}:printjobqueue", Environment.MachineName),
            //    WorkerCount = 10,
            //    Queues = new[] { "printjobqueue" }

            //};
            _server = new BackgroundJobServer();
        }
        public void Stop()
        {
            _server.Dispose();
        }
    }
}
