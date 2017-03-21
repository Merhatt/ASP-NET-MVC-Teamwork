using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VideoGameStore.Web.Controllers
{
    public class AdminController : Controller
    {
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult AddGame()
        {
            return View("~/Views/Admin/AddGame.cshtml");
        }
    }
}