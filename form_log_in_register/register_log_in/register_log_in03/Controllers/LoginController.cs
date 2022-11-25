using register_log_in03.Models;
using System;
using System.Security.Cryptography;
using System.Text;
using System.Web.Mvc;

namespace register_log_in03.Controllers
{
    public class LoginController : Controller
    {
        private ContextDB db = new ContextDB();
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        // GET: Login
        [HttpPost]
        public ActionResult Index(User u)
        {
            SHA256 sha = SHA256.Create();
            byte[] rs = sha.ComputeHash(Encoding.UTF8.GetBytes(u.UserPassword));
            u.UserPassword = BitConverter.ToString(rs).Replace("-", string.Empty);

            User user = db.Users.Find(u.UserName);
            if (user == null)
            {
                ViewBag.LoginError = "Tên đăng nhập hoặc mật khẩu không đúng!!!";
                return View();
            }
            else
            {

                TempData["UserName"] = u.UserName;
                return RedirectToAction("Index", "Home");
            }

        }
    }
}