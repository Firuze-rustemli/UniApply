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
    public class uni_dateController : Controller
    {
        private ApplyEntities3 db = new ApplyEntities3();

        // GET: Back/uni_date
        public ActionResult Index()
        {
            return View(db.uni_date.ToList());
        }

        // GET: Back/uni_date/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            uni_date uni_date = db.uni_date.Find(id);
            if (uni_date == null)
            {
                return HttpNotFound();
            }
            return View(uni_date);
        }

        // GET: Back/uni_date/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Back/uni_date/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,graduate_date,start_date")] uni_date uni_date)
        {
            if (ModelState.IsValid)
            {
                db.uni_date.Add(uni_date);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(uni_date);
        }

        [Admlvl]
        // GET: Back/uni_date/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            uni_date uni_date = db.uni_date.Find(id);
            if (uni_date == null)
            {
                return HttpNotFound();
            }
            return View(uni_date);
        }

        [Admlvl]
        // POST: Back/uni_date/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,graduate_date,start_date")] uni_date uni_date)
        {
            if (ModelState.IsValid)
            {
                db.Entry(uni_date).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(uni_date);
        }

        [Admlvl]
        // GET: Back/uni_date/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            uni_date uni_date = db.uni_date.Find(id);
            if (uni_date == null)
            {
                return HttpNotFound();
            }
            return View(uni_date);
        }
        [Admlvl]
        // POST: Back/uni_date/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            uni_date uni_date = db.uni_date.Find(id);
            db.uni_date.Remove(uni_date);
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
