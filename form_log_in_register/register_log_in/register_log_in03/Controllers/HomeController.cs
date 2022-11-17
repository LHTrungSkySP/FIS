using System.Web.Mvc;

namespace register_log_in03.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "𝕮𝖚𝖓𝖌 𝖈ấ𝖕 𝖙𝖍ô𝖓𝖌 𝖙𝖎𝖓 đă𝖓𝖌 𝖓𝖍ậ𝖕 𝖈ủ𝖆 𝖇ạ𝖓";
            return View();
        }
    }
}