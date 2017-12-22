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
    public class Uni_factController : Controller
    {
        private ApplyEntities3 db = new ApplyEntities3();

        // GET: Back/Uni_fact
        public ActionResult Index()
        {
            return View(db.Uni_fact.ToList());
        }

        // GET: Back/Uni_fact/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Uni_fact uni_fact = db.Uni_fact.Find(id);
            if (uni_fact == null)
            {
                return HttpNotFound();
            }
            return View(uni_fact);
        }

        // GET: Back/Uni_fact/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Back/Uni_fact/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,name,point")] Uni_fact uni_fact)
        {
            if (ModelState.IsValid)
            {
                db.Uni_fact.Add(uni_fact);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(uni_fact);
        }

        [Admlvl]
        // GET: Back/Uni_fact/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Uni_fact uni_fact = db.Uni_fact.Find(id);
            if (uni_fact == null)
            {
                return HttpNotFound();
            }
            return View(uni_fact);
        }
        [Admlvl]
        // POST: Back/Uni_fact/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,name,point")] Uni_fact uni_fact)
        {
            if (ModelState.IsValid)
            {
                db.Entry(uni_fact).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(uni_fact);
        }

        [Admlvl]
        // GET: Back/Uni_fact/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Uni_fact uni_fact = db.Uni_fact.Find(id);
            if (uni_fact == null)
            {
                return HttpNotFound();
            }
            return View(uni_fact);
        }

        [Admlvl]
        // POST: Back/Uni_fact/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Uni_fact uni_fact = db.Uni_fact.Find(id);
            db.Uni_fact.Remove(uni_fact);
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
