using Hangfire.Tasks;
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
            BackgroundJob.Enqueue(() => HgTask.PerformSomeLongRunningTask(15));
            return RedirectToAction("Index");
        }

    }

}