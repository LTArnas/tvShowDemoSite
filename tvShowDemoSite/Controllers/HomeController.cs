using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using tvShowDemoSite.DAL;
using tvShowDemoSite.Models;

namespace tvShowDemoSite.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index(ShowModel show)
        {
            ShowRepository repo = new ShowRepository();

            List<ShowModel> shows;

            if (ModelState.IsValidField("Title"))
                shows = repo.Find(x => x.Title == show.Title, 100);
            else
                shows = repo.Find(x => x.Title != null, 100);

            return View(shows);
        }
    }
}