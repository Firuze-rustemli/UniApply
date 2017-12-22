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
    public class LanguagesController : Controller
    {
        private ApplyEntities3 db = new ApplyEntities3();

        // GET: Back/Languages
        public ActionResult Index()
        {
            var language = db.Language.Include(l => l.profiency).Include(l => l.Test_type);
            return View(language.ToList());
        }

        // GET: Back/Languages/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Language language = db.Language.Find(id);
            if (language == null)
            {
                return HttpNotFound();
            }
            return View(language);
        }

        // GET: Back/Languages/Create
        public ActionResult Create()
        {
            ViewBag.profiency_id = new SelectList(db.profiency, "id", "profiency_level");
            ViewBag.test_type_id = new SelectList(db.Test_type, "id", "type_name");
            return View();
        }

        // POST: Back/Languages/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,lang_name,profiency_id,test_type_id,score")] Language language)
        {
            if (ModelState.IsValid)
            {
                db.Language.Add(language);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.profiency_id = new SelectList(db.profiency, "id", "profiency_level", language.profiency_id);
            ViewBag.test_type_id = new SelectList(db.Test_type, "id", "type_name", language.test_type_id);
            return View(language);
        }

        [Admlvl]
        // GET: Back/Languages/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Language language = db.Language.Find(id);
            if (language == null)
            {
                return HttpNotFound();
            }
            ViewBag.profiency_id = new SelectList(db.profiency, "id", "profiency_level", language.profiency_id);
            ViewBag.test_type_id = new SelectList(db.Test_type, "id", "type_name", language.test_type_id);
            return View(language);
        }

        [Admlvl]
        // POST: Back/Languages/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,lang_name,profiency_id,test_type_id,score")] Language language)
        {
            if (ModelState.IsValid)
            {
                db.Entry(language).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.profiency_id = new SelectList(db.profiency, "id", "profiency_level", language.profiency_id);
            ViewBag.test_type_id = new SelectList(db.Test_type, "id", "type_name", language.test_type_id);
            return View(language);
        }

        [Admlvl]
        // GET: Back/Languages/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Language language = db.Language.Find(id);
            if (language == null)
            {
                return HttpNotFound();
            }
            return View(language);
        }

        [Admlvl]
        // POST: Back/Languages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Language language = db.Language.Find(id);
            db.Language.Remove(language);
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
