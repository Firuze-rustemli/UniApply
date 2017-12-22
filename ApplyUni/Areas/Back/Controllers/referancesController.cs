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
    public class referancesController : Controller
    {
        private ApplyEntities3 db = new ApplyEntities3();

        // GET: Back/referances
        public ActionResult Index()
        {
            return View(db.referance.ToList());
        }

        // GET: Back/referances/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            referance referance = db.referance.Find(id);
            if (referance == null)
            {
                return HttpNotFound();
            }
            return View(referance);
        }

        // GET: Back/referances/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Back/referances/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,ref_firstname,ref_lastname,ref_email,ref_Phone,ref_relation,essasy")] referance referance)
        {
            if (ModelState.IsValid)
            {
                db.referance.Add(referance);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(referance);
        }

        [Admlvl]
        // GET: Back/referances/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            referance referance = db.referance.Find(id);
            if (referance == null)
            {
                return HttpNotFound();
            }
            return View(referance);
        }

        [Admlvl]
        // POST: Back/referances/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,ref_firstname,ref_lastname,ref_email,ref_Phone,ref_relation,essasy")] referance referance)
        {
            if (ModelState.IsValid)
            {
                db.Entry(referance).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(referance);
        }

        [Admlvl]
        // GET: Back/referances/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            referance referance = db.referance.Find(id);
            if (referance == null)
            {
                return HttpNotFound();
            }
            return View(referance);
        }

        [Admlvl]
        // POST: Back/referances/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            referance referance = db.referance.Find(id);
            db.referance.Remove(referance);
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
