using Online_Learning.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Online_Learning.Controllers
{
    public class LoginController : Controller
    {
        OnlineLearningEntities1 userRepo = new OnlineLearningEntities1();
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(User user)
        {
            if (ModelState.IsValid)
            {
              using (OnlineLearningEntities1 data = new OnlineLearningEntities1())
              {
                var obj = data.Users.Where(a => a.Username.Equals(user.Username) && a.Password.Equals(user.Password)).FirstOrDefault();
                if (obj != null)
                {
                    Session["UserID"] = obj.UserID.ToString();
                    Session["Username"] = obj.Username.ToString();
                    //Session["UserType"] = obj.UserType.ToString();
                    if (obj.UserType.ToString() == "admin")
                        
                            return RedirectToAction("AdminDashboard");
                          
                    else if (obj.UserType.ToString() == "teacher")
                        
                            return RedirectToAction("TeacherDashboard");
                        
                    else if (obj.UserType.ToString() == "student")
                        
                            return RedirectToAction("StudentDashboard");
                        
                }
              }
            }
          return RedirectToAction("Login");
        }
        [HttpGet]
        public ActionResult AdminDashboard()
        {
            return View();
        }
        [HttpGet]
        public ActionResult TeacherDashboard()
        {
            return View();
        }
        [HttpGet]
        public ActionResult StudentDashboard()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Login");
        }
        [HttpGet]
        public ActionResult SignUp()
        {
            User[] users = userRepo.Users.ToArray();
            ViewData["users"] = users;
            return View();
        }
        [HttpPost]
        public ActionResult SignUp(User u)
        {
            userRepo.Users.Add(u);
            userRepo.SaveChanges();
            return RedirectToAction("Login");
        }
    }
}