using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VideoGameStore.Web.Controllers
{
    public class GameInfoController : Controller
    {
        [HttpGet]
        public ActionResult Index(int id)
        {
            return View("~/Views/Game/GameInfo.cshtml");
        }
    }
}