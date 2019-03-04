using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Bi_WeeklyProject_6.Models;
using Bi_WeeklyProject6.Models;

namespace Bi_WeeklyProject_6.Controllers
{
    public class DocumentsController : Controller
    {
        private Models.Database db = new Models.Database();

        // GET: Documents
        [Authorize(Roles = "Manager,Analyst,Programmer,Architect,Tester")]
        public ActionResult Index()
        {
            User loggedinUSer = Session["User"] as User;
            IEnumerable<Task> documents = db.Tasks.Where(x => x.Role == loggedinUSer.Role).Include(d => d.User);
            if (documents == null)
            {
                documents = new List<Task>();
            }

            return View(documents.ToList());
        }
        [Authorize(Roles = "Manager,Analyst,Programmer,Architect,Tester")]
        public ActionResult Complete(int id)
        {
            Task task = db.Tasks.Where(x => x.Id == id).FirstOrDefault();
            if (task.Role == Roles.Manager)
            {
                return RedirectToAction("Index", "Home");
            }
            task.Role += 1;
            db.Entry(task).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
        // GET: Documents/Details/5
        [Authorize(Roles = "Manager,Analyst,Programmer,Architect,Tester")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Task task = db.Tasks.Find(id);
            if (task == null)
            {
                return HttpNotFound();
            }
            return View(task);
        }

        // GET: Documents/Create
        [Authorize(Roles = "Analyst")]
        public ActionResult Create()
        {
            ViewBag.UserID = new SelectList(db.Users, "Id", "Username");
            return View();
        }

        // POST: Documents/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Analyst")]
        public ActionResult Create([Bind(Include = "Id,Name,Text,Role,UserID")] Task task)
        {
            if (ModelState.IsValid)
            {
                User loggedinUSer = Session["User"] as User;
                task.UserID = loggedinUSer.Id;
                task.Role = loggedinUSer.Role;
                db.Task.Add(task);
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            ViewBag.UserID = new SelectList(db.Users, "Id", "Username", task.UserID);
            return View(task);
        }

        // GET: Documents/Edit/5
        [Authorize(Roles = "Manager,Analyst,Programmer,Architect,Tester")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Task task = db.Task.Find(id);
            if (task == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserID = new SelectList(db.Users, "Id", "Username", task.UserID);
            return View(task);
        }

        // POST: Documents/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Manager,Analyst,Programmer,Architect,Tester")]
        public ActionResult Edit([Bind(Include = "Id,Name,Text,Role,UserID")] Task task)
        {
            if (ModelState.IsValid)
            {
                User loggedinUSer = Session["User"] as User;
                task.UserID = loggedinUSer.Id;
                task.Role = loggedinUSer.Role;
                db.Entry(task).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserID = new SelectList(db.Users, "Id", "Username", task.UserID);
            return View(task);
        }

        // GET: Documents/Delete/5
        [Authorize(Roles = "Manager")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Task task = db.Task.Find(id);
            if (task == null)
            {
                return HttpNotFound();
            }
            return View(task);
        }

        // POST: Documents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Manager")]
        public ActionResult DeleteConfirmed(int id)
        {
            Task task = db.Documents.Find(id);
            db.Task.Remove(task);
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
