using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ApplyUni.Models;
using ApplyUni.Filter;

namespace ApplyUni.Areas.Back.Controllers
{
    [Auth]
    public class Type_blogController : Controller
    {
       
        private ApplyEntities3 db = new ApplyEntities3();

        // GET: Back/Type_blog
        public ActionResult Index()
        {
            return View(db.Type_blog.ToList());
        }

        // GET: Back/Type_blog/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Type_blog type_blog = db.Type_blog.Find(id);
            if (type_blog == null)
            {
                return HttpNotFound();
            }
            return View(type_blog);
        }

        // GET: Back/Type_blog/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Back/Type_blog/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,name")] Type_blog type_blog)
        {
            if (ModelState.IsValid)
            {
                db.Type_blog.Add(type_blog);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(type_blog);
        }
        [Admlvl]
        // GET: Back/Type_blog/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Type_blog type_blog = db.Type_blog.Find(id);
            if (type_blog == null)
            {
                return HttpNotFound();
            }
            return View(type_blog);
        }

        [Admlvl]
        // POST: Back/Type_blog/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,name")] Type_blog type_blog)
        {
            if (ModelState.IsValid)
            {
                db.Entry(type_blog).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(type_blog);
        }
        [Admlvl]
        // GET: Back/Type_blog/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Type_blog type_blog = db.Type_blog.Find(id);
            if (type_blog == null)
            {
                return HttpNotFound();
            }
            return View(type_blog);
        }
        [Admlvl]
        // POST: Back/Type_blog/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Type_blog type_blog = db.Type_blog.Find(id);
            db.Type_blog.Remove(type_blog);
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
