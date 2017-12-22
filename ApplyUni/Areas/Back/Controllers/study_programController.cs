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
    public class study_programController : Controller
    {
        private ApplyEntities3 db = new ApplyEntities3();

        // GET: Back/study_program
        public ActionResult Index()
        {
            var study_program = db.study_program.Include(s => s.study_field);
            return View(study_program.ToList());
        }

        // GET: Back/study_program/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            study_program study_program = db.study_program.Find(id);
            if (study_program == null)
            {
                return HttpNotFound();
            }
            return View(study_program);
        }

        // GET: Back/study_program/Create
        public ActionResult Create()
        {
            ViewBag.field_id = new SelectList(db.study_field, "id", "field_name");
            return View();
        }

        // POST: Back/study_program/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,program_name,program_fee,field_id")] study_program study_program)
        {
            if (ModelState.IsValid)
            {
                db.study_program.Add(study_program);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.field_id = new SelectList(db.study_field, "id", "field_name", study_program.field_id);
            return View(study_program);
        }

        [Admlvl]
        // GET: Back/study_program/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            study_program study_program = db.study_program.Find(id);
            if (study_program == null)
            {
                return HttpNotFound();
            }
            ViewBag.field_id = new SelectList(db.study_field, "id", "field_name", study_program.field_id);
            return View(study_program);
        }

        [Admlvl]
        // POST: Back/study_program/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,program_name,program_fee,field_id")] study_program study_program)
        {
            if (ModelState.IsValid)
            {
                db.Entry(study_program).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.field_id = new SelectList(db.study_field, "id", "field_name", study_program.field_id);
            return View(study_program);
        }

        [Admlvl]
        // GET: Back/study_program/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            study_program study_program = db.study_program.Find(id);
            if (study_program == null)
            {
                return HttpNotFound();
            }
            return View(study_program);
        }
        [Admlvl]
        // POST: Back/study_program/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            study_program study_program = db.study_program.Find(id);
            db.study_program.Remove(study_program);
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
