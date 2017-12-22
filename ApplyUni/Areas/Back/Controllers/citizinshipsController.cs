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
    public class citizinshipsController : Controller
    {
        private ApplyEntities3 db = new ApplyEntities3();

        // GET: Back/citizinships
        public ActionResult Index()
        {
            return View(db.citizinship.ToList());
        }

        // GET: Back/citizinships/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            citizinship citizinship = db.citizinship.Find(id);
            if (citizinship == null)
            {
                return HttpNotFound();
            }
            return View(citizinship);
        }

        // GET: Back/citizinships/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Back/citizinships/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,citizinship1")] citizinship citizinship)
        {
            if (ModelState.IsValid)
            {
                db.citizinship.Add(citizinship);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(citizinship);
        }

        [Admlvl]
        // GET: Back/citizinships/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            citizinship citizinship = db.citizinship.Find(id);
            if (citizinship == null)
            {
                return HttpNotFound();
            }
            return View(citizinship);
        }
        [Admlvl]
        // POST: Back/citizinships/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,citizinship1")] citizinship citizinship)
        {
            if (ModelState.IsValid)
            {
                db.Entry(citizinship).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(citizinship);
        }
        [Admlvl]
        // GET: Back/citizinships/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            citizinship citizinship = db.citizinship.Find(id);
            if (citizinship == null)
            {
                return HttpNotFound();
            }
            return View(citizinship);
        }
        [Admlvl]
        // POST: Back/citizinships/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            citizinship citizinship = db.citizinship.Find(id);
            db.citizinship.Remove(citizinship);
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
