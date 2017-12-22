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
    public class Uni_detailController : Controller
    {
        private ApplyEntities3 db = new ApplyEntities3();

        // GET: Back/Uni_detail
        public ActionResult Index()
        {
            return View(db.Uni_detail.ToList());
        }

        // GET: Back/Uni_detail/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Uni_detail uni_detail = db.Uni_detail.Find(id);
            if (uni_detail == null)
            {
                return HttpNotFound();
            }
            return View(uni_detail);
        }

        // GET: Back/Uni_detail/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Back/Uni_detail/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,average_tution,accept_rate,scholorship,student_fac_retio,information")] Uni_detail uni_detail)
        {
            if (ModelState.IsValid)
            {
                db.Uni_detail.Add(uni_detail);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(uni_detail);
        }

        [Admlvl]
        // GET: Back/Uni_detail/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Uni_detail uni_detail = db.Uni_detail.Find(id);
            if (uni_detail == null)
            {
                return HttpNotFound();
            }
            return View(uni_detail);
        }

        [Admlvl]
        // POST: Back/Uni_detail/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,average_tution,accept_rate,scholorship,student_fac_retio,information")] Uni_detail uni_detail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(uni_detail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(uni_detail);
        }
        [Admlvl]
        // GET: Back/Uni_detail/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Uni_detail uni_detail = db.Uni_detail.Find(id);
            if (uni_detail == null)
            {
                return HttpNotFound();
            }
            return View(uni_detail);
        }
        [Admlvl]
        // POST: Back/Uni_detail/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Uni_detail uni_detail = db.Uni_detail.Find(id);
            db.Uni_detail.Remove(uni_detail);
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
