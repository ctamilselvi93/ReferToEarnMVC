using ReferToEarnMVC.Context;
using ReferToEarnMVC.Models;
using System;
using System.Linq;
using System.Web.Mvc;

namespace ReferToEarnMVC.Controllers
{
    public class AccountController : Controller
    {
        private AppDBContext db = new AppDBContext();

        public ActionResult Register(string refCode)
        {
            var model = new RegisterView
            {
                ReferralCode = refCode
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult Register(RegisterView model)
        {
            if (ModelState.IsValid)
            {
                if (db.User.Any(u => u.MobileNumber == model.MobileNumber))
                {
                    ModelState.AddModelError("", "Mobile number already registered.");
                    return View(model);
                }

                var referralCode = Guid.NewGuid().ToString().Substring(0, 8);

                var user = new User
                {
                    Name = model.Name,
                    MobileNumber = model.MobileNumber,
                    PasswordHash = model.Password,
                    ReferralCode = referralCode,
                    ReferredBy = model.ReferralCode
                };

                db.User.Add(user);
                db.SaveChanges();

                if (!string.IsNullOrEmpty(model.ReferralCode))
                {
                    var referrer = db.User.FirstOrDefault(u => u.ReferralCode == model.ReferralCode);
                    if (referrer != null)
                    {
                        referrer.Points += 2;
                        db.SaveChanges();
                    }
                }

                Session["UserId"] = user.UserId;
                return RedirectToAction("Dashboard");
            }

            return View(model);
        }

        public ActionResult Dashboard()
        {
            if (Session["UserId"] == null)
                return RedirectToAction("Register");

            int id = (int)Session["UserId"];
            var user = db.User.Find(id);

            if (user == null)
                return HttpNotFound();

            return View("Dashboard", user);
        }
        public ActionResult AllUser()
        {
            var users = db.User.ToList();
            return View(users);
        }
    }
}