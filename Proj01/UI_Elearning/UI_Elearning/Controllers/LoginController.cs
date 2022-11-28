using System;
using System.Security.Cryptography;
using System.Text;
using System.Web.Mvc;
using UI_Elearning.Models;

namespace UI_Elearning.Controllers
{
    public class LoginController : Controller
    {
        private DbConenction db = new DbConenction();
        // GET: Login
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]

        public ActionResult IndexComfirm()
        {
            return View();
        }
        [HttpGet]

        public ActionResult PasswordRecovery()
        {
            return View();
        }
        [HttpGet]

        public ActionResult PasswordChange()
        {
            return View();
        }
        [HttpGet]

        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(FormCollection f)
        {

            User _user = db.Users.Find(f["Name"]);
            if (_user != null)
            {
                SHA256 sha = SHA256.Create();
                byte[] rs = sha.ComputeHash(Encoding.UTF8.GetBytes(f["pass"]));
                var pass = BitConverter.ToString(rs).Replace("-", string.Empty);
                if (pass == _user.AccountPassword)
                {
                    return RedirectToAction("IndexNeedComplete", "Home");
                }
            }
            return View();
        }
        [HttpPost]
        public ActionResult Register(User u)
        {
            try
            {
                if (u.AccountPassword != Request["AccountPasswordComfirm"])
                {

                    ViewBag.ComfirmPassword = false;
                    return View("Register");
                }
                SHA256 sha = SHA256.Create();
                byte[] rs = sha.ComputeHash(Encoding.UTF8.GetBytes(u.AccountPassword));
                u.AccountPassword = BitConverter.ToString(rs).Replace("-", string.Empty);
                u.Sex = (Request["GioiTinh"] == "Nam" ? true : false);
                db.Users.Add(u);
                db.SaveChanges();
                return View("Index");
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Lỗi nhập dữ liệu! " + ex.Message;
                return View("Register", u);
            }
        }
    }
}