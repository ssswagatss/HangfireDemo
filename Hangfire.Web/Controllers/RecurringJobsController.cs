using Hangfire.Storage;
using Hangfire.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Hangfire.Web.Controllers
{
    public class RecurringJobsController : Controller
    {
        public const string jobId = "100";
        public ActionResult Index()
        {
            List<RecurringJobDto> recurringJobDtos = new List<RecurringJobDto>();
            using (var connection = JobStorage.Current.GetConnection())
            {
                recurringJobDtos.AddRange(connection.GetRecurringJobs());
            }
            return View(recurringJobDtos);
        }

        //[HttpPost]
        //public ActionResult Schedule(int minutes)
        //{
        //    RecurringJob.AddOrUpdate(jobId, () => HgTask.PerformSomeRecurringTask(), Cron.MinuteInterval(minutes));
        //    return RedirectToAction("Index");
        //}
        //[HttpPost]
        //public ActionResult Update(int minutes)
        //{
        //    RecurringJob.AddOrUpdate(jobId, () => HgTask.PerformSomeRecurringTask(), Cron.MinuteInterval(minutes));
        //    return RedirectToAction("Index");
        //}
        //[HttpPost]
        //public ActionResult TriggerNow()
        //{
        //    RecurringJob.Trigger(jobId);
        //    return RedirectToAction("Index");
        //}
        //[HttpPost]
        //public ActionResult Remove()
        //{
        //    RecurringJob.RemoveIfExists(jobId);
        //    return RedirectToAction("Index");
        //}
    }
}
