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
    public class degree_levelController : Controller
    {
        private ApplyEntities3 db = new ApplyEntities3();

        // GET: Back/degree_level
        public ActionResult Index()
        {
            return View(db.degree_level.ToList());
        }

        // GET: Back/degree_level/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            degree_level degree_level = db.degree_level.Find(id);
            if (degree_level == null)
            {
                return HttpNotFound();
            }
            return View(degree_level);
        }

        // GET: Back/degree_level/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Back/degree_level/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,level,value")] degree_level degree_level)
        {
            if (ModelState.IsValid)
            {
                db.degree_level.Add(degree_level);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(degree_level);
        }

        [Admlvl]
        // GET: Back/degree_level/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            degree_level degree_level = db.degree_level.Find(id);
            if (degree_level == null)
            {
                return HttpNotFound();
            }
            return View(degree_level);
        }

        [Admlvl]
        // POST: Back/degree_level/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,level,value")] degree_level degree_level)
        {
            if (ModelState.IsValid)
            {
                db.Entry(degree_level).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(degree_level);
        }
        [Admlvl]
        // GET: Back/degree_level/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            degree_level degree_level = db.degree_level.Find(id);
            if (degree_level == null)
            {
                return HttpNotFound();
            }
            return View(degree_level);
        }
        [Admlvl]
        // POST: Back/degree_level/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            degree_level degree_level = db.degree_level.Find(id);
            db.degree_level.Remove(degree_level);
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
