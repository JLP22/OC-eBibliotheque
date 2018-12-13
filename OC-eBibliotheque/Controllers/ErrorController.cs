using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OC_eBibliotheque.Controllers
{
    public class ErrorController : Controller
    {
        /* 
        // GET: /Error/  
        public ActionResult Index()
        {
            return View("Error");
        }
        public ActionResult NotFound()
        {
            return View("Error");
        }*/
        public ActionResult NotFound()
        {
            Response.StatusCode = (int)System.Net.HttpStatusCode.NotFound;
            Response.StatusDescription = "404 Not Found";

            return View("Error");
        }
    }
}