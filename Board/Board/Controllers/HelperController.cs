using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Board.Models;

namespace Board.Controllers
{
    public class HelperController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();

        // GET: Helper
        public ActionResult Index(int id)
        {

            {
                var category = from c in db.Categories
                               join q in db.Questions on c.Id equals q.CategoryId
                               where c.Id == id
                               select c;
                var categoryName = category.First().Name;
                return PartialView(categoryName);

            }
        }
    }
}