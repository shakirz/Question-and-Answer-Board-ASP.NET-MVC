using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Board.Models;

namespace Board.Controllers
{
    public class QuestionController : Controller
    {
        //private BoardDbContext db = new BoardDbContext();
        ApplicationDbContext db = new ApplicationDbContext();

        // GET: Question
        public ActionResult Index()
        {
            return View(db.Questions.ToList());
        }

        public ActionResult Categorized(int categId)
        {
            var model =
                from s in db.Questions
                join c in db.Categories on s.CategoryId equals c.Id
                where s.CategoryId == categId
                select new QuestionViewModel()
                {
                    Id = s.Id,
                    AnswerCount = s.AnswerCount,
                    CategoryId = s.CategoryId,
                    Date = s.Date,
                    Name = s.Name,
                    ViewrCount = s.ViewrCount,
                    VoteCount = s.VoteCount,
                    Category = c.Name
                };

            return View(model);
        }


        public ActionResult GetCategory(int id)
        {
            var category = from c in db.Categories
                           join q in db.Questions on c.Id equals q.CategoryId
                           where c.Id == id
                           select c;
            var categoryName = category.First().Name;
            return Content(categoryName);
        }

        // GET: Question/Details/5
        public ActionResult Details(int? id)
        {
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            //Question question = db.Questions.Find(id);
            //if (question == null)
            //{
            //    return HttpNotFound();
            //}
            //return View(question);

            var model =
                from q in db.Questions
                join c in db.Categories on q.CategoryId equals c.Id
                join a in db.Answers on q.Id equals a.QuestionId
                where q.Id == id
                select new QuestionViewModel()
                {
                    Id = q.Id,
                    Name = q.Name,
                    Date = q.Date,
                    VoteCount = q.VoteCount,
                    AnswerCount = q.AnswerCount,
                    ViewrCount = q.AnswerCount,
                    //Answers = q.Answers,
                   // Category = c.Name
                };
            return View(model);
        }

        // GET: Question/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Question/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Date,CategoryId,VoteCount,AnswerCount,ViewrCount,Body")] Question question)
        {
            if (ModelState.IsValid)
            {
                question.AnswerCount = 0;
                question.VoteCount = 0;
                question.ViewrCount = 0;
                question.Date = DateTime.Now;        

                db.Questions.Add(question);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(question);
        }

        // GET: Question/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Question question = db.Questions.Find(id);
            if (question == null)
            {
                return HttpNotFound();
            }
            return View(question);
        }

        // POST: Question/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Date,CategoryId,VoteCount,AnswerCount,ViewrCount,Body")] Question question)
        {
            if (ModelState.IsValid)
            {
                db.Entry(question).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(question);
        }

        // GET: Question/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Question question = db.Questions.Find(id);
            if (question == null)
            {
                return HttpNotFound();
            }
            return View(question);
        }

        // POST: Question/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Question question = db.Questions.Find(id);
            db.Questions.Remove(question);
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
