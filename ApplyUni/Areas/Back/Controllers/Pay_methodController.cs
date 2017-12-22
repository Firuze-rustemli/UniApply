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
    public class Pay_methodController : Controller
    {
        private ApplyEntities3 db = new ApplyEntities3();

        // GET: Back/Pay_method
        public ActionResult Index()
        {
            return View(db.Pay_method.ToList());
        }

        // GET: Back/Pay_method/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pay_method pay_method = db.Pay_method.Find(id);
            if (pay_method == null)
            {
                return HttpNotFound();
            }
            return View(pay_method);
        }

        // GET: Back/Pay_method/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Back/Pay_method/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,card_name")] Pay_method pay_method)
        {
            if (ModelState.IsValid)
            {
                db.Pay_method.Add(pay_method);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pay_method);
        }

        [Admlvl]
        // GET: Back/Pay_method/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pay_method pay_method = db.Pay_method.Find(id);
            if (pay_method == null)
            {
                return HttpNotFound();
            }
            return View(pay_method);
        }

        [Admlvl]
        // POST: Back/Pay_method/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,card_name")] Pay_method pay_method)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pay_method).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pay_method);
        }

        [Admlvl]
        // GET: Back/Pay_method/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pay_method pay_method = db.Pay_method.Find(id);
            if (pay_method == null)
            {
                return HttpNotFound();
            }
            return View(pay_method);
        }
        [Admlvl]
        // POST: Back/Pay_method/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Pay_method pay_method = db.Pay_method.Find(id);
            db.Pay_method.Remove(pay_method);
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
