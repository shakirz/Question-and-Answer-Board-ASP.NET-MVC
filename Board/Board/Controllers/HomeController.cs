using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Board.Models;

namespace Board.Controllers
{
    public class HomeController : Controller
    {
        //BoardDbContext db = new BoardDbContext();
        ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            var model = db.Questions.ToList();
            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}