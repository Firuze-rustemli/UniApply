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
    public class PaymentsController : Controller
    {
        private ApplyEntities3 db = new ApplyEntities3();

        // GET: Back/Payments
        public ActionResult Index()
        {
            var payment = db.Payment.Include(p => p.Pay_method).Include(p => p.Users);
            return View(payment.ToList());
        }

        // GET: Back/Payments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Payment payment = db.Payment.Find(id);
            if (payment == null)
            {
                return HttpNotFound();
            }
            return View(payment);
        }

        // GET: Back/Payments/Create
        public ActionResult Create()
        {
            ViewBag.pay_method_id = new SelectList(db.Pay_method, "id", "card_name");
            ViewBag.user_id = new SelectList(db.Users, "id", "first_name");
            return View();
        }

        // POST: Back/Payments/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,user_id,card_name,card_number,cvn_number,date,pay_method_id")] Payment payment)
        {
            if (ModelState.IsValid)
            {
                db.Payment.Add(payment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.pay_method_id = new SelectList(db.Pay_method, "id", "card_name", payment.pay_method_id);
            ViewBag.user_id = new SelectList(db.Users, "id", "first_name", payment.user_id);
            return View(payment);
        }

        [Admlvl]
        // GET: Back/Payments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Payment payment = db.Payment.Find(id);
            if (payment == null)
            {
                return HttpNotFound();
            }
            ViewBag.pay_method_id = new SelectList(db.Pay_method, "id", "card_name", payment.pay_method_id);
            ViewBag.user_id = new SelectList(db.Users, "id", "first_name", payment.user_id);
            return View(payment);
        }

        // POST: Back/Payments/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,user_id,card_name,card_number,cvn_number,date,pay_method_id")] Payment payment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(payment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.pay_method_id = new SelectList(db.Pay_method, "id", "card_name", payment.pay_method_id);
            ViewBag.user_id = new SelectList(db.Users, "id", "first_name", payment.user_id);
            return View(payment);
        }

        // GET: Back/Payments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Payment payment = db.Payment.Find(id);
            if (payment == null)
            {
                return HttpNotFound();
            }
            return View(payment);
        }

        // POST: Back/Payments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Payment payment = db.Payment.Find(id);
            db.Payment.Remove(payment);
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
