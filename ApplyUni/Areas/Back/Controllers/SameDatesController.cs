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
using System.IO;

namespace ApplyUni.Areas.Back.Controllers
{
    [Auth]
    public class SameDatesController : Controller
    {
        private ApplyEntities3 db = new ApplyEntities3();

        // GET: Back/SameDates
        public ActionResult Index()
        {
            return View(db.SameDate.ToList());
        }

        // GET: Back/SameDates/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SameDate sameDate = db.SameDate.Find(id);
            if (sameDate == null)
            {
                return HttpNotFound();
            }
            return View(sameDate);
        }

        // GET: Back/SameDates/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Back/SameDates/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,logo,facebook,linkedin,twitter,google,instagram,phone,location")] SameDate sameDate, HttpPostedFileBase logo)
        {
            if (ModelState.IsValid)
            {
                if (logo == null)
                {
                    Session["uploadError"] = "Your must select your file";
                    return RedirectToAction("create");
                }
                if (logo.ContentType != "image/png" && logo.ContentType != "image/jpeg" && logo.ContentType != "image/gif")
                {
                    Session["uploadError"] = "Your file must be jpg,png or gif";
                    return RedirectToAction("create");
                }
                if ((logo.ContentLength / 1024) > 1024)
                {
                    Session["uploadError"] = "Your file size must be max 1mb";
                    return RedirectToAction("create");
                }
                string filename = DateTime.Now.ToString("ddMMyyyyHHmmssffff") + logo.FileName;
                string path = Path.Combine(Server.MapPath("~/Uploads"), filename);
                logo.SaveAs(path);
                sameDate.logo = filename;
                db.SameDate.Add(sameDate);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sameDate);
        }

        [Admlvl]
        // GET: Back/SameDates/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SameDate sameDate = db.SameDate.Find(id);
            if (sameDate == null)
            {
                return HttpNotFound();
            }
            return View(sameDate);
        }
        [Admlvl]
        // POST: Back/SameDates/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,logo,facebook,linkedin,twitter,google,instagram,phone,location")] SameDate sameDate, HttpPostedFileBase logo)
        {
            if (ModelState.IsValid)
            {
                if (logo != null)
                {
                    if (logo.ContentType != "image/png" && logo.ContentType != "image/jpg" && logo.ContentType != "image/gif" && logo.ContentType != "image/jpeg")
                    {
                        Session["uploadError"] = "your file must be jpg, png, gif, jpeg";
                        return RedirectToAction("update", "post_galery", new { id = sameDate.id });
                    }
                    if ((logo.ContentLength / 1024) > 1024)
                    {
                        Session["uploadError"] = "your file size must be max 1mb";
                        return RedirectToAction("update", "post_galery", new { id = sameDate.id });
                    }

                    string FileDate = DateTime.Now.ToString("ddMMyyyHHmmssffff") + logo.FileName;
                    string path = Path.Combine(Server.MapPath("~/Uploads"), FileDate);
                    //string oldpath = Path.Combine(Server.MapPath("~/Uploads"), OldPhoto);
                    //    if (System.IO.File.Exists(oldpath))
                    //    {
                    //        System.IO.File.Delete(oldpath);
                    //    }
                    logo.SaveAs(path);
                    sameDate.logo = FileDate;
                }
                //else
                //{
                //   post_galery.photo = OldPhoto;
                //}
                db.Entry(sameDate).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sameDate);
        }
        [Admlvl]
        // GET: Back/SameDates/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SameDate sameDate = db.SameDate.Find(id);
            if (sameDate == null)
            {
                return HttpNotFound();
            }
            return View(sameDate);
        }
        [Admlvl]
        // POST: Back/SameDates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SameDate sameDate = db.SameDate.Find(id);
            db.SameDate.Remove(sameDate);
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
