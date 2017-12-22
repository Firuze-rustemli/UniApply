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
    public class study_field_uniController : Controller
    {
        private ApplyEntities3 db = new ApplyEntities3();

        // GET: Back/study_field_uni
        public ActionResult Index()
        {
            var study_field_uni = db.study_field_uni.Include(s => s.study_field).Include(s => s.University);
            return View(study_field_uni.ToList());
        }

        // GET: Back/study_field_uni/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            study_field_uni study_field_uni = db.study_field_uni.Find(id);
            if (study_field_uni == null)
            {
                return HttpNotFound();
            }
            return View(study_field_uni);
        }

        // GET: Back/study_field_uni/Create
        public ActionResult Create()
        {
            ViewBag.study_field_id = new SelectList(db.study_field, "id", "field_name");
            ViewBag.uni_id = new SelectList(db.University, "id", "name");
            return View();
        }

        // POST: Back/study_field_uni/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,uni_id,study_field_id")] study_field_uni study_field_uni)
        {
            if (ModelState.IsValid)
            {
                db.study_field_uni.Add(study_field_uni);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.study_field_id = new SelectList(db.study_field, "id", "field_name", study_field_uni.study_field_id);
            ViewBag.uni_id = new SelectList(db.University, "id", "name", study_field_uni.uni_id);
            return View(study_field_uni);
        }

        [Admlvl]
        // GET: Back/study_field_uni/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            study_field_uni study_field_uni = db.study_field_uni.Find(id);
            if (study_field_uni == null)
            {
                return HttpNotFound();
            }
            ViewBag.study_field_id = new SelectList(db.study_field, "id", "field_name", study_field_uni.study_field_id);
            ViewBag.uni_id = new SelectList(db.University, "id", "name", study_field_uni.uni_id);
            return View(study_field_uni);
        }

        [Admlvl]
        // POST: Back/study_field_uni/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,uni_id,study_field_id")] study_field_uni study_field_uni)
        {
            if (ModelState.IsValid)
            {
                db.Entry(study_field_uni).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.study_field_id = new SelectList(db.study_field, "id", "field_name", study_field_uni.study_field_id);
            ViewBag.uni_id = new SelectList(db.University, "id", "name", study_field_uni.uni_id);
            return View(study_field_uni);
        }

        [Admlvl]
        // GET: Back/study_field_uni/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            study_field_uni study_field_uni = db.study_field_uni.Find(id);
            if (study_field_uni == null)
            {
                return HttpNotFound();
            }
            return View(study_field_uni);
        }

        [Admlvl]
        // POST: Back/study_field_uni/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            study_field_uni study_field_uni = db.study_field_uni.Find(id);
            db.study_field_uni.Remove(study_field_uni);
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
