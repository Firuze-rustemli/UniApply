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
    public class profienciesController : Controller
    {

        private ApplyEntities3 db = new ApplyEntities3();

        // GET: Back/profiencies
        public ActionResult Index()
        {
            return View(db.profiency.ToList());
        }

        // GET: Back/profiencies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            profiency profiency = db.profiency.Find(id);
            if (profiency == null)
            {
                return HttpNotFound();
            }
            return View(profiency);
        }

        // GET: Back/profiencies/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Back/profiencies/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,profiency_level")] profiency profiency)
        {
            if (ModelState.IsValid)
            {
                db.profiency.Add(profiency);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(profiency);
        }

        [Admlvl]
        // GET: Back/profiencies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            profiency profiency = db.profiency.Find(id);
            if (profiency == null)
            {
                return HttpNotFound();
            }
            return View(profiency);
        }

        [Admlvl]
        // POST: Back/profiencies/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,profiency_level")] profiency profiency)
        {
            if (ModelState.IsValid)
            {
                db.Entry(profiency).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(profiency);
        }
        [Admlvl]
        // GET: Back/profiencies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            profiency profiency = db.profiency.Find(id);
            if (profiency == null)
            {
                return HttpNotFound();
            }
            return View(profiency);
        }

        [Admlvl]
        // POST: Back/profiencies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            profiency profiency = db.profiency.Find(id);
            db.profiency.Remove(profiency);
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
