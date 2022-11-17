using register_log_in03.Models;
using System.Web.Mvc;

namespace register_log_in03.Areas.Admin.Controllers
{
    public class UsersController : Controller
    {
        private ContextDB db = new ContextDB();

        // GET: Admin/Users
        public ActionResult Index(User u)
        {
            User user = db.Users.Find(u.UserName);
            ViewBag.UserNameError = "";
            ViewBag.UserPassError = "";
            if (user == null)
            {
                ViewBag.UserNameError = "Tên đăng nhập không tồn tại!!!";
            }
            else
            {
                if (user.UserPassword != u.UserPassword)
                {
                    ViewBag.UserPassError = "Mật khẩu sai!!!";
                }
            }
            return View();
            //return View(db.Users.ToList());
        }

    }
}
