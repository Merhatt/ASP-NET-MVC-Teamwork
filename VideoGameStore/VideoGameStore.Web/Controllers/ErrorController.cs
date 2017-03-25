using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VideoGameStore.Web.Controllers
{
    public class ErrorController : Controller
    {
        // GET: Error
        [HandleError]
        public ActionResult NotFoundError()
        {
            return View("~/Views/Error/NotFoundError.cshtml");
        }

        [HandleError]
        public ActionResult ServerError()
        {
            return View("~/Views/Error/ServerError.cshtml");
        }
    }
}