using register_log_in03.Models;
using System;
using System.Data.Entity;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Web.Mvc;

namespace register_log_in03.Controllers
{
    public class RegisterController : Controller
    {
        private ContextDB db = new ContextDB();

        // GET: Register
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(User u)
        {
            User user = db.Users.Find(u.UserName);
            SHA256 sha = SHA256.Create();
            byte[] rs = sha.ComputeHash(Encoding.UTF8.GetBytes(u.UserPassword));
            u.UserPassword = BitConverter.ToString(rs).Replace("-", string.Empty);

            rs = sha.ComputeHash(Encoding.UTF8.GetBytes(Request["UserPassComfirm"]));
            string UserPassword = BitConverter.ToString(rs).Replace("-", string.Empty);

            if (user != null)
            {
                ViewBag.Error = "Tên đăng nhập đã tồn tại!!!";
                return View();
            }
            else if (UserPassword == u.UserPassword)
            {
                db.Users.Add(u);
                db.SaveChanges();
                return RedirectToAction("Index", "login");
            }
            else
            {
                ViewBag.Error = "Vui lòng nhập lại mật khẩu";
                return View();
            }
        }

        // GET: Register/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // GET: Register/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Register/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserName,UserPassword")] User user)
        {
            if (ModelState.IsValid)
            {
                db.Users.Add(user);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(user);
        }

        // GET: Register/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Register/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserName,UserPassword")] User user)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(user);
        }

        // GET: Register/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Register/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            User user = db.Users.Find(id);
            db.Users.Remove(user);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
