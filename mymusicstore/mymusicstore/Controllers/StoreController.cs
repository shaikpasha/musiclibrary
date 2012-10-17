using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using mymusicstore.Models;
namespace mymusicstore.Controllers
{
    public class StoreController : Controller
    {
        //
        // GET: /Store/
        MusicStoreEntities storedb = new MusicStoreEntities();

        public ActionResult Index()
        {
            var genre = storedb.Genres.ToList();
            
             return View(genre);
        }
        public ActionResult Detail(int id)
        {
            var album = storedb.Albums.Find(id);

            return View(album);
        }
        public ActionResult Browse(string id)
        {
            var genre = storedb.Genres.Include("Albums").Single(g => g.Name == id);
            return View(genre);
        }
    }
}
