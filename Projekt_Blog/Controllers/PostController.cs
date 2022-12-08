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
    public class PostController : Controller
    {
        private SoulsborneBlogContext db = new SoulsborneBlogContext();

        // GET: Post
        public ActionResult Index()
        {
            var posts = db.posts.Include(p => p.category).Include(p => p.user);
            return View(posts.ToList());
        }

        // GET: Post/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            post posts = db.posts.Find(id);
            if (posts == null)
            {
                return HttpNotFound();
            }
            return View(posts);
        }

        // GET: Post/Create
        public ActionResult Create()
        {
            ViewBag.kategoria_id = new SelectList(db.categories, "kategoria_id", "Kategoria");
            ViewBag.user_id = new SelectList(db.users, "user_id", "nick");
            return View();
        }

        // POST: Post/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "post_id,kategoria_id,user_id,Temat,Gra,Tresc,data_dodania")] post posts)
        {
            if (ModelState.IsValid)
            {
                db.posts.Add(posts);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.kategoria_id = new SelectList(db.categories, "kategoria_id", "Kategoria", posts.kategoria_id);
            ViewBag.user_id = new SelectList(db.users, "user_id", "nick", posts.user_id);
            return View(posts);
        }

        // GET: Post/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            post posts = db.posts.Find(id);
            if (posts == null)
            {
                return HttpNotFound();
            }
            ViewBag.kategoria_id = new SelectList(db.categories, "kategoria_id", "Kategoria", posts.kategoria_id);
            ViewBag.user_id = new SelectList(db.users, "user_id", "nick", posts.user_id);
            return View(posts);
        }

        // POST: Post/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "post_id,kategoria_id,user_id,Temat,Gra,Tresc,data_dodania")] post posts)
        {
            if (ModelState.IsValid)
            {
                db.Entry(posts).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.kategoria_id = new SelectList(db.categories, "kategoria_id", "Kategoria", posts.kategoria_id);
            ViewBag.user_id = new SelectList(db.users, "user_id", "nick", posts.user_id);
            return View(posts);
        }

        // GET: Post/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            post posts = db.posts.Find(id);
            if (posts == null)
            {
                return HttpNotFound();
            }
            return View(posts);
        }

        // POST: Post/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            post posts = db.posts.Find(id);
            db.posts.Remove(posts);
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
