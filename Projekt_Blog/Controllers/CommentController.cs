using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Projekt_Blog.Models;

namespace Projekt_Blog.Controllers
{
    public class CommentController : Controller
    {
        private SoulsborneBlogContext db = new SoulsborneBlogContext();

        // GET: Comment
        public ActionResult Index()
        {
            var comments = db.comments.Include(c => c.post).Include(c => c.user);
            return View(comments.ToList());
        }

        // GET: Comment/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            comment comments = db.comments.Find(id);
            if (comments == null)
            {
                return HttpNotFound();
            }
            return View(comments);
        }

        // GET: Comment/Create
        public ActionResult Create()
        {
            ViewBag.post_id = new SelectList(db.posts, "post_id", "Temat");
            ViewBag.user_id = new SelectList(db.users, "user_id", "nick");
            return View();
        }

        // POST: Comment/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_comment,post_id,user_id,Tresc")] comment comments)
        {
            if (ModelState.IsValid)
            {
                db.comments.Add(comments);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.post_id = new SelectList(db.posts, "post_id", "Temat", comments.post_id);
            ViewBag.user_id = new SelectList(db.users, "user_id", "nick", comments.user_id);
            return View(comments);
        }

        // GET: Comment/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            comment comments = db.comments.Find(id);
            if (comments == null)
            {
                return HttpNotFound();
            }
            ViewBag.post_id = new SelectList(db.posts, "post_id", "Temat", comments.post_id);
            ViewBag.user_id = new SelectList(db.users, "user_id", "nick", comments.user_id);
            return View(comments);
        }

        // POST: Comment/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_comment,post_id,user_id,Tresc")] comment comments)
        {
            if (ModelState.IsValid)
            {
                db.Entry(comments).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.post_id = new SelectList(db.posts, "post_id", "Temat", comments.post_id);
            ViewBag.user_id = new SelectList(db.users, "user_id", "nick", comments.user_id);
            return View(comments);
        }

        // GET: Comment/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            comment comments = db.comments.Find(id);
            if (comments == null)
            {
                return HttpNotFound();
            }
            return View(comments);
        }

        // POST: Comment/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            comment comments = db.comments.Find(id);
            db.comments.Remove(comments);
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
