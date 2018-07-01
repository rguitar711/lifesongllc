using LifeSongComposers.Models;
using LifeSongComposers.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LifeSongComposers.Controllers
{
    public class StoreController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Store
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult TrackListing()
        {
            var allTracks = db.Tracks;
            var list = new List<TrackList>();
            

            foreach(var t in allTracks)
            {
                list.Add(new TrackList
                {
                    Genre = t.Genre,
                    Title = t.Title,
                    Path = t.FileName
                });
            }


                   

            return View(list);

        }


        [HttpGet]
        public ActionResult VocalListing()
        {
            var allTracks = db.Tracks;
            var list = new List<TrackList>();


            foreach (var t in allTracks)
            {
                list.Add(new TrackList
                {
                    Genre = t.Genre,
                    Title = t.Title,
                    Path = t.FileName
                });
            }




            return View(list);
        }

        [HttpGet]
        public ActionResult YourStory()
        {
            return View();
        }
    }
}