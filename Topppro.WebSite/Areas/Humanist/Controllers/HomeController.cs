﻿using System.Web.Mvc;

namespace Topppro.WebSite.Areas.Humanist.Controllers
{
    public class HomeController : Controller
    {
        [OutputCache(CacheProfile = "Long")]
        public ActionResult Index()
        {
            return View();
        }

    }
}
