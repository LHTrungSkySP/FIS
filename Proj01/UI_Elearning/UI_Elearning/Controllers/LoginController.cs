using System;
using System.Linq;
using System.Net.Mail;
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
                    if (_user.AccountName == "user09")
                    {
                        return RedirectToAction("Index", "Admin");
                    }
                    else
                    {
                        return RedirectToAction("IndexNeedComplete", "Home");
                    }
                }
            }
            return View();
        }
        [HttpPost]
        public ActionResult Register(User u)
        {
            try
            {
                if (u.AccountPassword != null && u.AccountPassword != Request["AccountPasswordComfirm"].ToString())
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
        [HttpPost]
        public ActionResult PasswordChange(FormCollection f)
        {
            User _user = db.Users.Find(f[""]);
            return View();
        }
        [HttpPost]
        public ActionResult PasswordRecovery(FormCollection f)
        {
            string str = f["Email"];
            var users = (from item in db.Users
                         where item.Email.Equals(str)
                         select item).ToList();
            if (users.Count == 0)
            {
                ViewBag.Error = "Không tồn tại Email";
                return View("PasswordRecovery");
            }
            else
            {
                MailMessage mail = new MailMessage();
                mail.To.Add("trungchochett@gmail.com");
                mail.From = new MailAddress("hqobtzy@karenkey.com");
                mail.Subject = "Xác nhận đổi mật khẩu";
                string Body = "Nếu yêu cầu đổi mật khẩu đến từ bạn hãy truy cập link <br/> <a>https://localhost:44384/Login/PasswordChange<a/>";
                mail.Body = Body;
                mail.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new System.Net.NetworkCredential("hqobtzy@karenkey.com", "C'ZUK_.s"); // Enter seders User name and password  
                smtp.EnableSsl = true;
                smtp.Send(mail);
                ViewBag.Error = "Check email của bạn!!!";
                return View("PasswordRecovery");

            }
        }
    }
}