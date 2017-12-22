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
    public class Acount_valueController : Controller
    {
        private ApplyEntities3 db = new ApplyEntities3();

        // GET: Back/Acount_value
        public ActionResult Index()
        {
            var acount_value = db.Acount_value.Include(a => a.acount_plan);
            return View(acount_value.ToList());
        }

        // GET: Back/Acount_value/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Acount_value acount_value = db.Acount_value.Find(id);
            if (acount_value == null)
            {
                return HttpNotFound();
            }
            return View(acount_value);
        }

        // GET: Back/Acount_value/Create
        public ActionResult Create()
        {
            ViewBag.acount_plan_id = new SelectList(db.acount_plan, "id", "title");
            return View();
        }

        // POST: Back/Acount_value/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,name,acount_plan_id")] Acount_value acount_value)
        {
            if (ModelState.IsValid)
            {
                db.Acount_value.Add(acount_value);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.acount_plan_id = new SelectList(db.acount_plan, "id", "title", acount_value.acount_plan_id);
            return View(acount_value);
        }

        [Admlvl]
        // GET: Back/Acount_value/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Acount_value acount_value = db.Acount_value.Find(id);
            if (acount_value == null)
            {
                return HttpNotFound();
            }
            ViewBag.acount_plan_id = new SelectList(db.acount_plan, "id", "title", acount_value.acount_plan_id);
            return View(acount_value);
        }

        [Admlvl]
        // POST: Back/Acount_value/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,name,acount_plan_id")] Acount_value acount_value)
        {
            if (ModelState.IsValid)
            {
                db.Entry(acount_value).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.acount_plan_id = new SelectList(db.acount_plan, "id", "title", acount_value.acount_plan_id);
            return View(acount_value);
        }

        [Admlvl]
        // GET: Back/Acount_value/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Acount_value acount_value = db.Acount_value.Find(id);
            if (acount_value == null)
            {
                return HttpNotFound();
            }
            return View(acount_value);
        }

        [Admlvl]
        // POST: Back/Acount_value/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Acount_value acount_value = db.Acount_value.Find(id);
            db.Acount_value.Remove(acount_value);
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
