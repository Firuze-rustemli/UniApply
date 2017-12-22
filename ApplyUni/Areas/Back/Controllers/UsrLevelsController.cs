using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ApplyUni.Models;
using ApplyUni.Filter;

namespace ApplyUni.Areas.Back.Controllers
{
    [Auth]
    public class UsrLevelsController : Controller
    {
        private ApplyEntities3 db = new ApplyEntities3();

        // GET: Back/UsrLevels
        public async Task<ActionResult> Index()
        {
            return View(await db.UsrLevel.ToListAsync());
        }

        // GET: Back/UsrLevels/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UsrLevel usrLevel = await db.UsrLevel.FindAsync(id);
            if (usrLevel == null)
            {
                return HttpNotFound();
            }
            return View(usrLevel);
        }
        [Admlvl]
        // GET: Back/UsrLevels/Create
        public ActionResult Create()
        {
            return View();
        }
        [Admlvl]
        // POST: Back/UsrLevels/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id,level_name")] UsrLevel usrLevel)
        {
            if (ModelState.IsValid)
            {
                db.UsrLevel.Add(usrLevel);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(usrLevel);
        }
        [Admlvl]
        // GET: Back/UsrLevels/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UsrLevel usrLevel = await db.UsrLevel.FindAsync(id);
            if (usrLevel == null)
            {
                return HttpNotFound();
            }
            return View(usrLevel);
        }
        [Admlvl]
        // POST: Back/UsrLevels/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id,level_name")] UsrLevel usrLevel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(usrLevel).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(usrLevel);
        }
        [Admlvl]
        // GET: Back/UsrLevels/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UsrLevel usrLevel = await db.UsrLevel.FindAsync(id);
            if (usrLevel == null)
            {
                return HttpNotFound();
            }
            return View(usrLevel);
        }
        [Admlvl]
        // POST: Back/UsrLevels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            UsrLevel usrLevel = await db.UsrLevel.FindAsync(id);
            db.UsrLevel.Remove(usrLevel);
            await db.SaveChangesAsync();
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
