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
    public class study_fieldController : Controller
    {
        private ApplyEntities3 db = new ApplyEntities3();

        // GET: Back/study_field
        public ActionResult Index()
        {
            return View(db.study_field.ToList());
        }

        // GET: Back/study_field/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            study_field study_field = db.study_field.Find(id);
            if (study_field == null)
            {
                return HttpNotFound();
            }
            return View(study_field);
        }

        // GET: Back/study_field/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Back/study_field/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,field_name")] study_field study_field)
        {
            if (ModelState.IsValid)
            {
                db.study_field.Add(study_field);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(study_field);
        }
        [Admlvl]
        // GET: Back/study_field/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            study_field study_field = db.study_field.Find(id);
            if (study_field == null)
            {
                return HttpNotFound();
            }
            return View(study_field);
        }
        [Admlvl]
        // POST: Back/study_field/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,field_name")] study_field study_field)
        {
            if (ModelState.IsValid)
            {
                db.Entry(study_field).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(study_field);
        }

        [Admlvl]
        // GET: Back/study_field/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            study_field study_field = db.study_field.Find(id);
            if (study_field == null)
            {
                return HttpNotFound();
            }
            return View(study_field);
        }

        [Admlvl]
        // POST: Back/study_field/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            study_field study_field = db.study_field.Find(id);
            db.study_field.Remove(study_field);
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
