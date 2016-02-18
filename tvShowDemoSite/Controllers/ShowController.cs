using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using tvShowDemoSite.DAL;
using tvShowDemoSite.Models;

namespace tvShowDemoSite.Controllers
{
    public class ShowController : Controller
    {
        // TODO: refactor common operations into functions.

        ShowRepository repo = new ShowRepository();

        public ActionResult Index()
        {
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Create(string title)
        {
            /* The title parameter allows user to pass us the value in the URL.
            As a potential convenience, as it will pre-fill the form. 
            Because we fill out the model with that date, 
            then pass the model to the view, and that will pre-fill the form.
            */
            ShowModel show = new ShowModel
            {
                Id = ShowRepository.GenerateId(),
                Title = title
            };
            
            return View(show);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ShowModel show)
        {
            if (ModelState.IsValid)
            {
                if (repo.Get(show.Id) == null)
                    repo.Insert(show);
                else
                    return RedirectToAction("Index", "Home");
            }
            
            return View(show);
        }

        public ActionResult Read(string id)
        {
            if (id == null)
            {
                id = repo.Find(x => x.Title != null, 1)?.First()?.Id;
                
                if (id == null) // This should never happen.
                    throw new ArgumentNullException("Failed to get a fallback Id.");
            }

            ShowModel show = repo.Get(id);

            if (show == null)
                return RedirectToAction("Index", "Home");
            else
                return View(show);
        }

        public ActionResult Update(string id)
        {
            if (id == null)
            {
                id = repo.Find(x => x.Title != null, 1)?.First()?.Id;

                if (id == null) // This should never happen.
                    throw new ArgumentNullException("Failed to get a fallback Id.");
            }

            ShowModel show = repo.Get(id);

            if (show == null)
                return RedirectToAction("Index", "Home");
            else
                return View(show);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(ShowModel show)
        {
            if (ModelState.IsValid)
            {
                if (repo.Get(show.Id) != null)
                    repo.Replace(show);
                else
                    return RedirectToAction("Index", "Home");
            }

            return View(show);
        }

        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                id = repo.Find(x => x.Title != null, 1)?.First()?.Id;

                if (id == null) // This should never happen.
                    throw new ArgumentNullException("Failed to get a fallback Id.");
            }

            ShowModel show = repo.Get(id);

            if (show == null)
                return RedirectToAction("Index", "Home");
            else
                return View(show);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(ShowModel show)
        {
            if (ModelState.IsValid)
            {
                if (repo.Get(show.Id) != null)
                    repo.Delete(show.Id);
                else
                    return RedirectToAction("Index", "Home");
            }

            return View(show);
        }

        protected override void OnException(ExceptionContext filterContext)
        {
            // TODO: return exception page.
        }
    }
}