using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LifeSongComposers.Models;

namespace LifeSongComposers.Controllers
{
    public class TracksController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Tracks
        public ActionResult Index()
        {
            return View(db.Tracks.ToList());
        }

        // GET: Tracks/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Track track = db.Tracks.Find(id);
            if (track == null)
            {
                return HttpNotFound();
            }
            return View(track);
        }

        // GET: Tracks/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tracks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Title,Genre,Composer,Mood,Path,InsertDate,CreatedDate,ArchiveDate")] Track track, HttpPostedFileBase upload)
        {
            string trackfolder = "~/UploadedTracks";

            if (ModelState.IsValid)
            {
                try
                {
                    //upload file 
                    if (upload.ContentLength > 0)
                    {
                        
                        string _FileName = Path.GetFileName(upload.FileName);
                        string _path = Path.Combine(Server.MapPath(trackfolder), _FileName);
                        upload.SaveAs(_path);

                        ViewBag.Message = "File Uploaded Successfully!!";

                        track.ID = Guid.NewGuid();
                        track.FileName = trackfolder + "/"+_FileName;
                        track.Path = _path;
                        track.InsertDate = DateTime.Now;
                        track.ArchiveDate = DateTime.MaxValue;
                        db.Tracks.Add(track);
                        db.SaveChanges();

                        ViewBag.Message = "File upload Success!!";
                        return View(track);
                    }

                }
                catch (Exception e)
                {
                    ViewBag.Message = "File upload failed!!";
                    return View(track);
                }
               
                
                
            }

            return View(track);
        }

        // GET: Tracks/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Track track = db.Tracks.Find(id);
            if (track == null)
            {
                return HttpNotFound();
            }
            return View(track);
        }

        // POST: Tracks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Title,Genre,Composer,Mood,Path,InsertDate,CreatedDate,ArchiveDate")] Track track)
        {
            if (ModelState.IsValid)
            {
                db.Entry(track).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(track);
        }

        // GET: Tracks/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Track track = db.Tracks.Find(id);
            if (track == null)
            {
                return HttpNotFound();
            }
            return View(track);
        }

        // POST: Tracks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Track track = db.Tracks.Find(id);
            db.Tracks.Remove(track);
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
