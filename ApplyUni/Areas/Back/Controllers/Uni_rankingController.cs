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
    public class Uni_rankingController : Controller
    {
        private ApplyEntities3 db = new ApplyEntities3();

        // GET: Back/Uni_ranking
        public ActionResult Index()
        {
            return View(db.Uni_ranking.ToList());
        }

        // GET: Back/Uni_ranking/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Uni_ranking uni_ranking = db.Uni_ranking.Find(id);
            if (uni_ranking == null)
            {
                return HttpNotFound();
            }
            return View(uni_ranking);
        }

        // GET: Back/Uni_ranking/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Back/Uni_ranking/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,ranking_category")] Uni_ranking uni_ranking)
        {
            if (ModelState.IsValid)
            {
                db.Uni_ranking.Add(uni_ranking);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(uni_ranking);
        }

        [Admlvl]
        // GET: Back/Uni_ranking/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Uni_ranking uni_ranking = db.Uni_ranking.Find(id);
            if (uni_ranking == null)
            {
                return HttpNotFound();
            }
            return View(uni_ranking);
        }
        [Admlvl]
        // POST: Back/Uni_ranking/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,ranking_category")] Uni_ranking uni_ranking)
        {
            if (ModelState.IsValid)
            {
                db.Entry(uni_ranking).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(uni_ranking);
        }
        [Admlvl]
        // GET: Back/Uni_ranking/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Uni_ranking uni_ranking = db.Uni_ranking.Find(id);
            if (uni_ranking == null)
            {
                return HttpNotFound();
            }
            return View(uni_ranking);
        }
        [Admlvl]
        // POST: Back/Uni_ranking/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Uni_ranking uni_ranking = db.Uni_ranking.Find(id);
            db.Uni_ranking.Remove(uni_ranking);
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
