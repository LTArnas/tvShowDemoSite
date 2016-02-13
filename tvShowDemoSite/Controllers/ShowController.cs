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
        // TODO: add default Index() action ...prolly just redirect home.
        // TODO: add show repo here.
        // TODO: add common/standard viewbag variables here (ViewBag.Success = false;) 
        public ActionResult Create(string title)
        {
            /* The title parameter allows user to pass us the value in the URL.
            As a potential convenience, as it will pre-fill the form. 
            Because we fill out the model with that date, 
            then pass the model to the view, and that will pre-fill the form.
            */
            ShowModel show = new ShowModel();
            show.Id = ShowRepository.GenerateId();
            show.Title = title;
            return View(show);
        }

        [HttpPost]
        public ActionResult Create(ShowModel show)
        {
            // TODO: handle duplicate key entry (for refresh/resubmit)
            // ...then also add status notification.
            ShowRepository repo = new ShowRepository();
            repo.Insert(show);
            // only set status code once, for the actual create.
            // do not send the code again for refresh/resubmits ...send the right status code.
            Response.StatusCode = 201;
            ViewBag.Success = true;
            return View(show);
        }

        public ActionResult Read(string id)
        {
            ShowRepository repo = new ShowRepository();
            ShowModel show = repo.Get(id);
            return View(show);
        }

        public ActionResult Update(string id)
        {
            ShowRepository repo = new ShowRepository();
            ShowModel show = repo.Get(id);
            return View(show);
        }

        [HttpPost]
        public ActionResult Update(ShowModel show)
        {
            ShowRepository repo = new ShowRepository();
            repo.Replace(show);
            // TODO: add status code.
            ViewBag.Success = true;
            return View(show);
        }

        public ActionResult Delete(string id)
        {
            ShowRepository repo = new ShowRepository();
            ShowModel show = repo.Get(id);
            return View(show);
        }

        [HttpPost]
        public ActionResult Delete(ShowModel show)
        {
            ShowRepository repo = new ShowRepository();
            repo.Delete(show.Id);
            ViewBag.Success = true;
            return View(show);
        }
    }
}