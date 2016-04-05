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
        public ActionResult Index(ShowModel show, string networkFilter, string orderBy, bool orderAscending=false)
        {
            ShowRepository repo = new ShowRepository();

            List<ShowModel> shows;

            if (ModelState.IsValidField("Title"))
                shows = repo.Find(x => x.Title.ToLower().Contains(show.Title), 100);
            else
                shows = repo.Find(x => x.Title != null, 100);

            // pretty terrible filter/order solution, fix if it ever starts to be an issue...
            
            // Remember this doesn't use the database, but our previous query result.
            ViewBag.networksList = new SelectList(shows.GroupBy(x => x.Network).Select(x => x.First().Network));

            if (!string.IsNullOrWhiteSpace(networkFilter))
                shows = shows.FindAll(x => x.Network == networkFilter);

            switch (orderBy)
            {
                case "title":
                    if (orderAscending)
                        shows = shows.OrderBy(x => x.Title).ToList();
                    else
                        shows = shows.OrderByDescending(x => x.Title).ToList();
                    break;
                case "date":
                    if (orderAscending)
                        shows = shows.OrderBy(x => x.ReleaseDate).ToList();
                    else
                        shows = shows.OrderByDescending(x => x.ReleaseDate).ToList();
                    break;
                case "network":
                    if (orderAscending)
                        shows = shows.OrderBy(x => x.Network).ToList();
                    else
                        shows = shows.OrderByDescending(x => x.Network).ToList();
                    break;
                case "seasons":
                    if (orderAscending)
                        shows = shows.OrderBy(x => x.Seasons).ToList();
                    else
                        shows = shows.OrderByDescending(x => x.Seasons).ToList();
                    break;
                case "episodes":
                    if (orderAscending)
                        shows = shows.OrderBy(x => x.Episodes).ToList();
                    else
                        shows = shows.OrderByDescending(x => x.Episodes).ToList();
                    break;
            }

            return View(shows);
        }
        /*
        [HttpPost]
        public ActionResult Index(string filterBy, string filter, string sortBy, bool sortAscending)
        {
            ShowRepository repo = new ShowRepository();

            List<ShowModel> shows;

            switch (filterBy)
            {
                default:
                    shows = new List<ShowModel>();
                    break;
            }
            shows = repo.Find(x => x.Id != null);

            switch (sortBy)
            {
                case "title":
                    if (sortAscending)
                        shows = shows.OrderBy(x => x.Title).ToList();
                    else
                        shows = shows.OrderByDescending(x => x.Title).ToList();
                    break;
                case "date":
                    if (sortAscending)
                        shows = shows.OrderBy(x => x.ReleaseDate).ToList();
                    else
                        shows = shows.OrderByDescending(x => x.ReleaseDate).ToList();
                    break;
                case "network":
                    if (sortAscending)
                        shows = shows.OrderBy(x => x.Network).ToList();
                    else
                        shows = shows.OrderByDescending(x => x.Network).ToList();
                    break;
                case "seasons":
                    if (sortAscending)
                        shows = shows.OrderBy(x => x.Seasons).ToList();
                    else
                        shows = shows.OrderByDescending(x => x.Seasons).ToList();
                    break;
                case "episodes":
                    if (sortAscending)
                        shows = shows.OrderBy(x => x.Episodes).ToList();
                    else
                        shows = shows.OrderByDescending(x => x.Episodes).ToList();
                    break;
            }
            return View(shows);
        }
        */
    }
}