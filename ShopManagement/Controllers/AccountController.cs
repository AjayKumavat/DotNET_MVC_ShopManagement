using ShopManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopManagement.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(User userModel)
        {
            if (ModelState.IsValid)
            {
                using (var db = new ShopDbContext())
                {
                    User user = db.Users.Where(u => u.UserName == userModel.UserName && u.Password == userModel.Password).FirstOrDefault();

                    if (user != null)
                    {
                        Session["UserName"] = userModel.UserName;
                        Session["UserId"] = userModel.Id;
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Invalid Username or Password");
                        return View(userModel);
                    }
                }
            }
            else
            {
                return View(userModel);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOut()
        {
            Session["UserName"] = string.Empty;
            Session["UserId"] = string.Empty;
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public ActionResult Register(User userModel)
        {
            if(UsernameExists(userModel.UserName))
            {
                ModelState.AddModelError("", "Username already exists!");
                return View(userModel);
            }

            using (var db = new ShopDbContext())
            {
                var user = new User();

                user.UserName = userModel.UserName;
                user.Password = userModel.Password;
                user.RoleId = 1;

                db.Users.Add(user);
                db.SaveChanges();

                return RedirectToAction("Login", "Account");
            }
        }

        private bool UsernameExists(string userName)
        {
            using (var db = new ShopDbContext())
            {
                var result = db.Users.Where(u => u.UserName == userName).FirstOrDefault();

                if(result != null)
                {
                    return true;
                }
                return false;
            }
        }
    }
}