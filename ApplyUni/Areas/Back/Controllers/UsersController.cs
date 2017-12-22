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
    public class UsersController : Controller
    {
        private ApplyEntities3 db = new ApplyEntities3();

        // GET: Back/Users
        public ActionResult Index()
        {
            var users = db.Users.Include(u => u.Bugdet).Include(u => u.citizinship).Include(u => u.Country).Include(u => u.Country1).Include(u => u.degree_level).Include(u => u.study_field).Include(u => u.user_finance_plan);
            return View(users.ToList());
        }

        // GET: Back/Users/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Users users = db.Users.Find(id);
            if (users == null)
            {
                return HttpNotFound();
            }
            return View(users);
        }

        // GET: Back/Users/Create
        public ActionResult Create()
        {
            ViewBag.budget_id = new SelectList(db.Bugdet, "id", "id");
            ViewBag.citizinship_id = new SelectList(db.citizinship, "id", "citizinship1");
            ViewBag.user_country_id = new SelectList(db.Country, "id", "country_name");
            ViewBag.user_study_cont_id = new SelectList(db.Country, "id", "country_name");
            ViewBag.degree_level_id = new SelectList(db.degree_level, "id", "level");
            ViewBag.study_field_id = new SelectList(db.study_field, "id", "field_name");
            ViewBag.finance_plan_id = new SelectList(db.user_finance_plan, "id", "plan_name");
            return View();
        }

        // POST: Back/Users/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,first_name,last_name,email,password,birthday,phone,gender,user_country_id,study_field_id,user_study_cont_id,degree_level_id,finance_plan_id,budget_id,citizinship_id,adress,postcode")] Users users)
        {
            if (ModelState.IsValid)
            {
                db.Users.Add(users);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.budget_id = new SelectList(db.Bugdet, "id", "id", users.budget_id);
            ViewBag.citizinship_id = new SelectList(db.citizinship, "id", "citizinship1", users.citizinship_id);
            ViewBag.user_country_id = new SelectList(db.Country, "id", "country_name", users.user_country_id);
            ViewBag.user_study_cont_id = new SelectList(db.Country, "id", "country_name", users.user_study_cont_id);
            ViewBag.degree_level_id = new SelectList(db.degree_level, "id", "level", users.degree_level_id);
            ViewBag.study_field_id = new SelectList(db.study_field, "id", "field_name", users.study_field_id);
            ViewBag.finance_plan_id = new SelectList(db.user_finance_plan, "id", "plan_name", users.finance_plan_id);
            return View(users);
        }

        [Admlvl]
        // GET: Back/Users/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Users users = db.Users.Find(id);
            if (users == null)
            {
                return HttpNotFound();
            }
            ViewBag.budget_id = new SelectList(db.Bugdet, "id", "id", users.budget_id);
            ViewBag.citizinship_id = new SelectList(db.citizinship, "id", "citizinship1", users.citizinship_id);
            ViewBag.user_country_id = new SelectList(db.Country, "id", "country_name", users.user_country_id);
            ViewBag.user_study_cont_id = new SelectList(db.Country, "id", "country_name", users.user_study_cont_id);
            ViewBag.degree_level_id = new SelectList(db.degree_level, "id", "level", users.degree_level_id);
            ViewBag.study_field_id = new SelectList(db.study_field, "id", "field_name", users.study_field_id);
            ViewBag.finance_plan_id = new SelectList(db.user_finance_plan, "id", "plan_name", users.finance_plan_id);
            return View(users);
        }
        [Admlvl]
        // POST: Back/Users/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,first_name,last_name,email,password,birthday,phone,gender,user_country_id,study_field_id,user_study_cont_id,degree_level_id,finance_plan_id,budget_id,citizinship_id,adress,postcode")] Users users)
        {
            if (ModelState.IsValid)
            {
                db.Entry(users).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.budget_id = new SelectList(db.Bugdet, "id", "id", users.budget_id);
            ViewBag.citizinship_id = new SelectList(db.citizinship, "id", "citizinship1", users.citizinship_id);
            ViewBag.user_country_id = new SelectList(db.Country, "id", "country_name", users.user_country_id);
            ViewBag.user_study_cont_id = new SelectList(db.Country, "id", "country_name", users.user_study_cont_id);
            ViewBag.degree_level_id = new SelectList(db.degree_level, "id", "level", users.degree_level_id);
            ViewBag.study_field_id = new SelectList(db.study_field, "id", "field_name", users.study_field_id);
            ViewBag.finance_plan_id = new SelectList(db.user_finance_plan, "id", "plan_name", users.finance_plan_id);
            return View(users);
        }
        [Admlvl]
        // GET: Back/Users/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Users users = db.Users.Find(id);
            if (users == null)
            {
                return HttpNotFound();
            }
            return View(users);
        }
        [Admlvl]
        // POST: Back/Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Users users = db.Users.Find(id);
            db.Users.Remove(users);
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
