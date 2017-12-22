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
    public class user_finance_planController : Controller
    {
        private ApplyEntities3 db = new ApplyEntities3();

        // GET: Back/user_finance_plan
        public ActionResult Index()
        {
            return View(db.user_finance_plan.ToList());
        }

        // GET: Back/user_finance_plan/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            user_finance_plan user_finance_plan = db.user_finance_plan.Find(id);
            if (user_finance_plan == null)
            {
                return HttpNotFound();
            }
            return View(user_finance_plan);
        }

        // GET: Back/user_finance_plan/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Back/user_finance_plan/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,plan_name")] user_finance_plan user_finance_plan)
        {
            if (ModelState.IsValid)
            {
                db.user_finance_plan.Add(user_finance_plan);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(user_finance_plan);
        }

        [Admlvl]
        // GET: Back/user_finance_plan/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            user_finance_plan user_finance_plan = db.user_finance_plan.Find(id);
            if (user_finance_plan == null)
            {
                return HttpNotFound();
            }
            return View(user_finance_plan);
        }

        [Admlvl]
        // POST: Back/user_finance_plan/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,plan_name")] user_finance_plan user_finance_plan)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user_finance_plan).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(user_finance_plan);
        }

        [Admlvl]
        // GET: Back/user_finance_plan/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            user_finance_plan user_finance_plan = db.user_finance_plan.Find(id);
            if (user_finance_plan == null)
            {
                return HttpNotFound();
            }
            return View(user_finance_plan);
        }
        [Admlvl]
        // POST: Back/user_finance_plan/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            user_finance_plan user_finance_plan = db.user_finance_plan.Find(id);
            db.user_finance_plan.Remove(user_finance_plan);
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
