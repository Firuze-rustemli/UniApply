using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ApplyUni.Models;
using System.IO;
using ApplyUni.Filter;

namespace ApplyUni.Areas.Back.Controllers
{
    [Auth]
    public class post_galeryController : Controller
    {
        private ApplyEntities3 db = new ApplyEntities3();

        // GET: Back/post_galery
        public ActionResult Index() 
        {
            var post_galery = db.post_galery.Include(p => p.Type_blog);
            return View(post_galery.ToList());
        }

        // GET: Back/post_galery/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            post_galery post_galery = db.post_galery.Find(id);
            if (post_galery == null)
            {
                return HttpNotFound();
            }
            return View(post_galery);
        }

        // GET: Back/post_galery/Create
        public ActionResult Create()
        {
            ViewBag.type_id = new SelectList(db.Type_blog, "id", "name");
            return View();
        }


        // POST: Back/post_galery/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,title,photo,description,type_id")] post_galery post_galery, HttpPostedFileBase photo)
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
                post_galery.photo = filename;
                db.post_galery.Add(post_galery);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.type_id = new SelectList(db.Type_blog, "id", "name", post_galery.type_id);
            return View(post_galery);
        }

        [Admlvl]
        // GET: Back/post_galery/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            post_galery post_galery = db.post_galery.Find(id);
            if (post_galery == null)
            {
                return HttpNotFound();
            }
            ViewBag.type_id = new SelectList(db.Type_blog, "id", "name", post_galery.type_id);
            return View(post_galery);
        }

        [Admlvl]
        // POST: Back/post_galery/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,title,photo,description,type_id")] post_galery post_galery, HttpPostedFileBase photo, string OldPhoto)
        {
            if (ModelState.IsValid)
            {
                if (photo != null) { 
                if (photo.ContentType != "image/png" && photo.ContentType != "image/jpg" && photo.ContentType != "image/gif" && photo.ContentType != "image/jpeg")
                {
                    Session["uploadError"] = "your file must be jpg, png, gif, jpeg";
                    return RedirectToAction("update","post_galery",new { id=post_galery.id});
                }
                if ((photo.ContentLength / 1024) > 1024)
                {
                    Session["uploadError"] = "your file size must be max 1mb";
                        return RedirectToAction("update", "post_galery", new { id = post_galery.id });
                    }

                string FileDate = DateTime.Now.ToString("ddMMyyyHHmmssffff") + photo.FileName;
                string path = Path.Combine(Server.MapPath("~/Uploads"), FileDate);
               string oldpath = Path.Combine(Server.MapPath("~/Uploads"), OldPhoto);
                    if (System.IO.File.Exists(oldpath))
                    {
                        System.IO.File.Delete(oldpath);
                  }
                    photo.SaveAs(path);
                post_galery.photo = FileDate;
            }
                else
                {
                   post_galery.photo = OldPhoto;
                }
                db.Entry(post_galery).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.type_id = new SelectList(db.Type_blog, "id", "name", post_galery.type_id);
            return View(post_galery);

        }

        [Admlvl]
        // GET: Back/post_galery/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            post_galery post_galery = db.post_galery.Find(id);
            if (post_galery == null)
            {
                return HttpNotFound();
            }
            return View(post_galery);
        }

        [Admlvl]
        // POST: Back/post_galery/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            post_galery post_galery = db.post_galery.Find(id);
            db.post_galery.Remove(post_galery);
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
