using System.Web.Mvc;

namespace UI_Elearning.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult IndexNeedComplete()
        {
            return View();
        }
        public ActionResult IndexDone()
        {
            return View();
        }
        public ActionResult IndexDetailCourse()
        {
            return View();
        }
    }
}