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
    public class BugdetsController : Controller
    {
        private ApplyEntities3 db = new ApplyEntities3();

        // GET: Back/Bugdets
        public ActionResult Index()
        {
            return View(db.Bugdet.ToList());
        }

        // GET: Back/Bugdets/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bugdet bugdet = db.Bugdet.Find(id);
            if (bugdet == null)
            {
                return HttpNotFound();
            }
            return View(bugdet);
        }

        // GET: Back/Bugdets/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Back/Bugdets/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,max_budget,min_budget")] Bugdet bugdet)
        {
            if (ModelState.IsValid)
            {
                db.Bugdet.Add(bugdet);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bugdet);
        }

        [Admlvl]
        // GET: Back/Bugdets/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bugdet bugdet = db.Bugdet.Find(id);
            if (bugdet == null)
            {
                return HttpNotFound();
            }
            return View(bugdet);
        }
        [Admlvl]
        // POST: Back/Bugdets/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,max_budget,min_budget")] Bugdet bugdet)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bugdet).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bugdet);
        }
        [Admlvl]
        // GET: Back/Bugdets/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bugdet bugdet = db.Bugdet.Find(id);
            if (bugdet == null)
            {
                return HttpNotFound();
            }
            return View(bugdet);
        }
        [Admlvl]
        // POST: Back/Bugdets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Bugdet bugdet = db.Bugdet.Find(id);
            db.Bugdet.Remove(bugdet);
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
