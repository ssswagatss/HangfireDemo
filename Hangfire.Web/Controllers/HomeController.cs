using Hangfire.Tasks;
using System;
using System.Web.Mvc;

namespace Hangfire.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult RunTask()
        {
            HgTask.PerformSomeLongRunningTask(12);
            return RedirectToAction("Index");
        }
        public ActionResult RunTaskWithHangfire()
        {
            var jobId =  BackgroundJob.Schedule(() => HgTask.PerformSomeLongRunningTask(15),TimeSpan.FromSeconds(20));
            //You can use this ID to check the status of the job being processed !
            //var monitor = JobStorage.Current.GetMonitoringApi();
            //monitor.JobDetails(jobId)?.History.FirstOrDefault();
            return RedirectToAction("Index");
        }

    }

}