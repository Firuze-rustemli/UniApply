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
    public class UniversitiesController : Controller
    {
        private ApplyEntities3 db = new ApplyEntities3();

        // GET: Back/Universities
        public ActionResult Index()
        {
            var university = db.University.Include(u => u.rank_to_rait).Include(u => u.uni_date).Include(u => u.Uni_detail).Include(u => u.Uni_fact);
            return View(university.ToList());
        }

        // GET: Back/Universities/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            University university = db.University.Find(id);
            if (university == null)
            {
                return HttpNotFound();
            }
            return View(university);
        }

        // GET: Back/Universities/Create
        public ActionResult Create()
        {
            ViewBag.rank_to_rate_id = new SelectList(db.rank_to_rait, "id", "id");
            ViewBag.uni_date_id = new SelectList(db.uni_date, "id", "id");
            ViewBag.detail_id = new SelectList(db.Uni_detail, "id", "average_tution");
            ViewBag.fact_id = new SelectList(db.Uni_fact, "id", "id");
            return View();
        }

        // POST: Back/Universities/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,name,detail_id,fact_id,rank_to_rate_id,uni_date_id")] University university)
        {
            if (ModelState.IsValid)
            {
                db.University.Add(university);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.rank_to_rate_id = new SelectList(db.rank_to_rait, "id", "id", university.rank_to_rate_id);
            ViewBag.uni_date_id = new SelectList(db.uni_date, "id", "id", university.uni_date_id);
            ViewBag.detail_id = new SelectList(db.Uni_detail, "id", "average_tution", university.detail_id);
            ViewBag.fact_id = new SelectList(db.Uni_fact, "id", "id", university.fact_id);
            return View(university);
        }

        [Admlvl]
        // GET: Back/Universities/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            University university = db.University.Find(id);
            if (university == null)
            {
                return HttpNotFound();
            }
            ViewBag.rank_to_rate_id = new SelectList(db.rank_to_rait, "id", "id", university.rank_to_rate_id);
            ViewBag.uni_date_id = new SelectList(db.uni_date, "id", "id", university.uni_date_id);
            ViewBag.detail_id = new SelectList(db.Uni_detail, "id", "average_tution", university.detail_id);
            ViewBag.fact_id = new SelectList(db.Uni_fact, "id", "id", university.fact_id);
            return View(university);
        }

        [Admlvl]
        // POST: Back/Universities/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,name,detail_id,fact_id,rank_to_rate_id,uni_date_id")] University university)
        {
            if (ModelState.IsValid)
            {
                db.Entry(university).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.rank_to_rate_id = new SelectList(db.rank_to_rait, "id", "id", university.rank_to_rate_id);
            ViewBag.uni_date_id = new SelectList(db.uni_date, "id", "id", university.uni_date_id);
            ViewBag.detail_id = new SelectList(db.Uni_detail, "id", "average_tution", university.detail_id);
            ViewBag.fact_id = new SelectList(db.Uni_fact, "id", "id", university.fact_id);
            return View(university);
        }

        [Admlvl]
        // GET: Back/Universities/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            University university = db.University.Find(id);
            if (university == null)
            {
                return HttpNotFound();
            }
            return View(university);
        }

        [Admlvl]
        // POST: Back/Universities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            University university = db.University.Find(id);
            db.University.Remove(university);
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
