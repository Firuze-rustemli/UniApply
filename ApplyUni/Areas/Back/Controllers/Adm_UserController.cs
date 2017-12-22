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
using System.Web.Helpers;

namespace ApplyUni.Areas.Back.Controllers
{
    [Auth]
    public class Adm_UserController : Controller
    {
        private ApplyEntities3 db = new ApplyEntities3();

        // GET: Back/Adm_User
        public ActionResult Index()
        {
            var adm_User = db.Adm_User.Include(a => a.UsrLevel);
            return View(adm_User.ToList());
        }

        // GET: Back/Adm_User/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Adm_User adm_User = db.Adm_User.Find(id);
            if (adm_User == null)
            {
                return HttpNotFound();
            }
            return View(adm_User);
        }

        [Admlvl]
        // GET: Back/Adm_User/Create
        public ActionResult Create()
        {
            ViewBag.user_level = new SelectList(db.UsrLevel, "id", "level_name");
            return View();
        }
        [Admlvl]
        // POST: Back/Adm_User/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,fullname,email,password,user_level,photo")] Adm_User adm_User, HttpPostedFileBase photo)
        {
            if (ModelState.IsValid)
            {
                if (photo == null)
                {
                    Session["uploadError"] = "Your must select your file";
                    return RedirectToAction("create");
                }
                if (photo.ContentType != "image/png" && photo.ContentType != "image/jpeg" && photo.ContentType != "image/gif")
                {
                    Session["uploadError"] = "Your file must be jpg,png or gif";
                    return RedirectToAction("create");
                }
                if ((photo.ContentLength / 1024) > 1024)
                {
                    Session["uploadError"] = "Your file size must be max 1mb";
                    return RedirectToAction("create");
                }
                string filename = DateTime.Now.ToString("ddMMyyyyHHmmssffff") + photo.FileName;
                string path = Path.Combine(Server.MapPath("~/Uploads"), filename);
                photo.SaveAs(path);
                adm_User.photo = filename;
                db.Adm_User.Add(adm_User);
                adm_User.password = Crypto.HashPassword(adm_User.password);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.user_level = new SelectList(db.UsrLevel, "id", "level_name", adm_User.user_level);
            return View(adm_User);
        }
        [Admlvl]
        // GET: Back/Adm_User/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Adm_User adm_User = db.Adm_User.Find(id);
            if (adm_User == null)
            {
                return HttpNotFound();
            }
            ViewBag.user_level = new SelectList(db.UsrLevel, "id", "level_name", adm_User.user_level);
            return View(adm_User);
        }
        [Admlvl]
        // POST: Back/Adm_User/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,fullname,email,password,user_level,photo")] Adm_User adm_User, HttpPostedFileBase photo)
        {
            if (ModelState.IsValid)
            {
                if (photo != null)
                {
                    if (photo.ContentType != "image/png" && photo.ContentType != "image/jpg" && photo.ContentType != "image/gif" && photo.ContentType != "image/jpeg")
                    {
                        Session["uploadError"] = "your file must be jpg, png, gif, jpeg";
                        return RedirectToAction("update", "post_galery", new { id = adm_User.id });
                    }
                    if ((photo.ContentLength / 1024) > 1024)
                    {
                        Session["uploadError"] = "your file size must be max 1mb";
                        return RedirectToAction("update", "post_galery", new { id = adm_User.id });
                    }

                    string FileDate = DateTime.Now.ToString("ddMMyyyHHmmssffff") + photo.FileName;
                    string path = Path.Combine(Server.MapPath("~/Uploads"), FileDate);
                    //string oldpath = Path.Combine(Server.MapPath("~/Uploads"), OldPhoto);
                    //    if (System.IO.File.Exists(oldpath))
                    //    {
                    //        System.IO.File.Delete(oldpath);
                    //    }
                    photo.SaveAs(path);
                    adm_User.photo = FileDate;
                }
                //else
                //{
                //   post_galery.photo = OldPhoto;
                //}
                db.Entry(adm_User).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.user_level = new SelectList(db.UsrLevel, "id", "level_name", adm_User.user_level);
            return View(adm_User);
        }
        [Admlvl]
        // GET: Back/Adm_User/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Adm_User adm_User = db.Adm_User.Find(id);
            if (adm_User == null)
            {
                return HttpNotFound();
            }
            return View(adm_User);
        }
        [Admlvl]
        // POST: Back/Adm_User/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Adm_User adm_User = db.Adm_User.Find(id);
            db.Adm_User.Remove(adm_User);
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
