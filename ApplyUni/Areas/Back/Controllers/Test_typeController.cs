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
    public class Test_typeController : Controller
    {
        private ApplyEntities3 db = new ApplyEntities3();

        // GET: Back/Test_type
        public ActionResult Index()
        {
            return View(db.Test_type.ToList());
        }

        // GET: Back/Test_type/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Test_type test_type = db.Test_type.Find(id);
            if (test_type == null)
            {
                return HttpNotFound();
            }
            return View(test_type);
        }

        // GET: Back/Test_type/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Back/Test_type/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,type_name")] Test_type test_type)
        {
            if (ModelState.IsValid)
            {
                db.Test_type.Add(test_type);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(test_type);
        }

        [Admlvl]
        // GET: Back/Test_type/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Test_type test_type = db.Test_type.Find(id);
            if (test_type == null)
            {
                return HttpNotFound();
            }
            return View(test_type);
        }
        [Admlvl]
        // POST: Back/Test_type/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,type_name")] Test_type test_type)
        {
            if (ModelState.IsValid)
            {
                db.Entry(test_type).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(test_type);
        }
        [Admlvl]
        // GET: Back/Test_type/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Test_type test_type = db.Test_type.Find(id);
            if (test_type == null)
            {
                return HttpNotFound();
            }
            return View(test_type);
        }
        [Admlvl]
        // POST: Back/Test_type/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Test_type test_type = db.Test_type.Find(id);
            db.Test_type.Remove(test_type);
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
