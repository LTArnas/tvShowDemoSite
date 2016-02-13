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
        public ActionResult Index()
        {
            ShowRepository repo = new ShowRepository();
            List<ShowModel> shows = repo.Find(x => x.Title != null, 100);

            return View(shows);
        }

        public ActionResult Add(string id)
        {
            ShowRepository repo = new ShowRepository();
            ShowModel show = new ShowModel();
            show.Id = ShowRepository.GenerateId();
            show.Title = id;
            repo.Insert(show);
            return View(show);
        }
    }
}