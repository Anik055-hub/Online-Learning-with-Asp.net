using Online_Learning.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Online_Learning.Controllers
{
    public class AdminHomeController : Controller
    {
        OnlineLearningEntities1 userRepo  = new OnlineLearningEntities1();
        [HttpGet]
        public ActionResult Admin()
        {
            return View();
        }
        [HttpGet]
        public ActionResult ProfileInfo(int id)
        {
            var result = from item in userRepo.Users
                         where item.UserID == id
                         select item;
          //    User profile = result.FirstOrDefault();
          //  User p = userRepo.Users.Where(x => x.UserID == id).FirstOrDefault();
          //  p.UserID = id;
          //  return View(p);
            return View(result.FirstOrDefault());
        }
        [HttpGet]
        public ActionResult Teachers()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Students()
        {
            return View();
        }
        
        [HttpGet]
        public ActionResult Courses()
        {
            return View(userRepo.Courses.ToList());
        }
        [HttpGet]
        public ActionResult Blogs()
        {
            return View(userRepo.CourseMaterials.ToList());
        }
        [HttpGet]
        public ActionResult Messages()
        {
            return View();
        }

    }
}