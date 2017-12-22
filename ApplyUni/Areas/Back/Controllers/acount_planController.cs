
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
    public class acount_planController : Controller
    {
        private ApplyEntities3 db = new ApplyEntities3();

        // GET: Back/acount_plan
        public ActionResult Index()
        {
            return View(db.acount_plan.ToList());
        }

        // GET: Back/acount_plan/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            acount_plan acount_plan = db.acount_plan.Find(id);
            if (acount_plan == null)
            {
                return HttpNotFound();
            }
            return View(acount_plan);
        }

        // GET: Back/acount_plan/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Back/acount_plan/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,title,price,descriptin")] acount_plan acount_plan)
        {
            if (ModelState.IsValid)
            {
                db.acount_plan.Add(acount_plan);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(acount_plan);
        }

        [Admlvl]
        // GET: Back/acount_plan/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            acount_plan acount_plan = db.acount_plan.Find(id);
            if (acount_plan == null)
            {
                return HttpNotFound();
            }
            return View(acount_plan);
        }
        [Admlvl]
        // POST: Back/acount_plan/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,title,price,descriptin")] acount_plan acount_plan)
        {
            if (ModelState.IsValid)
            {
                db.Entry(acount_plan).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(acount_plan);
        }

        [Admlvl]
        // GET: Back/acount_plan/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            acount_plan acount_plan = db.acount_plan.Find(id);
            if (acount_plan == null)
            {
                return HttpNotFound();
            }
            return View(acount_plan);
        }

        [Admlvl]
        // POST: Back/acount_plan/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            acount_plan acount_plan = db.acount_plan.Find(id);
            db.acount_plan.Remove(acount_plan);
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
