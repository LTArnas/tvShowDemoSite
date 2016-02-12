using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace tvShowDemoSite.Controllers
{
    public class ShowController : Controller
    {
        public ActionResult Create(string title)
        {
            return View();
        }

        public ActionResult Read()
        {
            return View();
        }

        public ActionResult Update()
        {
            return View();
        }

        public ActionResult Delete()
        {
            return View();
        }
    }
}