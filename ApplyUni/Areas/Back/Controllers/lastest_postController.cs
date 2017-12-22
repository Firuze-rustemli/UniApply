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
    public class lastest_postController : Controller
    {
        private ApplyEntities3 db = new ApplyEntities3();

        // GET: Back/lastest_post
        public ActionResult Index()
        {
            var lastest_post = db.lastest_post.Include(l => l.Category);
            return View(lastest_post.ToList());
        }

        // GET: Back/lastest_post/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            lastest_post lastest_post = db.lastest_post.Find(id);
            if (lastest_post == null)
            {
                return HttpNotFound();
            }
            return View(lastest_post);
        }

        // GET: Back/lastest_post/Create
        public ActionResult Create()
        {
            ViewBag.category_id = new SelectList(db.Category, "id", "name");
            return View();
        }

        // POST: Back/lastest_post/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,photo,title,category_id,description")] lastest_post lastest_post, HttpPostedFileBase photo)
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
                lastest_post.photo = filename;
                db.lastest_post.Add(lastest_post);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.category_id = new SelectList(db.Category, "id", "name", lastest_post.category_id);
            return View(lastest_post);
        }
        [Admlvl]
        // GET: Back/lastest_post/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            lastest_post lastest_post = db.lastest_post.Find(id);
            if (lastest_post == null)
            {
                return HttpNotFound();
            }
            ViewBag.category_id = new SelectList(db.Category, "id", "name", lastest_post.category_id);
            return View(lastest_post);
        }
        [Admlvl]
        // POST: Back/lastest_post/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken, ValidateInput(false)]
        public ActionResult Edit([Bind(Include = "id,photo,title,category_id,description")] lastest_post lastest_post, HttpPostedFileBase photo, string Oldphoto)
        {
            if (ModelState.IsValid)
            {
                if (photo != null)
                {
                    if (photo.ContentType != "image/png" && photo.ContentType != "image/jpg" && photo.ContentType != "image/gif" && photo.ContentType != "image/jpeg")
                    {
                        Session["uploadError"] = "your file must be jpg, png, gif, jpeg";
                        return RedirectToAction("update", "post_galery", new { id = lastest_post.id });
                    }
                    if ((photo.ContentLength / 1024) > 1024)
                    {
                        Session["uploadError"] = "your file size must be max 1mb";
                        return RedirectToAction("update", "post_galery", new { id = lastest_post.id });
                    }

                    string FileDate = DateTime.Now.ToString("ddMMyyyHHmmssffff") + photo.FileName;
                    string path = Path.Combine(Server.MapPath("~/Uploads"), FileDate);
                    //string oldpath = Path.Combine(Server.MapPath("~/Uploads"), Oldphoto);
                    //System.IO.File.Delete(oldpath);
                    photo.SaveAs(path);
                    lastest_post.photo = FileDate;
                }
                //else
                //{
                //    lastest_post.photo = Oldphoto;
                //}
                db.Entry(lastest_post).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.category_id = new SelectList(db.Category, "id", "name", lastest_post.category_id);
            return View(lastest_post);
        }
        [Admlvl]
        // GET: Back/lastest_post/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            lastest_post lastest_post = db.lastest_post.Find(id);
            if (lastest_post == null)
            {
                return HttpNotFound();
            }
            return View(lastest_post);
        }
        [Admlvl]
        // POST: Back/lastest_post/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            lastest_post lastest_post = db.lastest_post.Find(id);
            db.lastest_post.Remove(lastest_post);
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
