using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VideoGameStore.Data.Models;
using VideoGameStore.Services;
using VideoGameStore.Services.Contracts;
using VideoGameStore.Web.Models;

namespace VideoGameStore.Web.Controllers
{
    public class GamesPageController : Controller
    {
        private IGameServices gameServices;

        public GamesPageController(IGameServices gameServices)
        {
            if (gameServices == null)
            {
                throw new NullReferenceException("gameServices cannot be null");
            }

            this.gameServices = gameServices;
        }

        [HttpGet]
        public ActionResult Index()
        {
            GamesPageViewModel model = new GamesPageViewModel();
            model.Games = this.gameServices.GetAll();

            model.Games = new List<Game>()
            {
                new Game()
                {
                    Name = "Battlefield 1",
                    Id = 1,
                    ImageUrl = "https://upload.wikimedia.org/wikipedia/en/f/fc/Battlefield_1_cover_art.jpg"
                }
            };

            return View("~/Views/Game/GamesPage.cshtml", model);
        }

        [HttpPost]
        public ActionResult SearchByName(GamesPageViewModel model)
        {
            model.Games = this.gameServices.GetAll(model.SearchName);

            return View("~/Views/Game/GamesPage.cshtml", model);
        }

        [Authorize]
        [HttpPost]
        public ActionResult AddToCart(int gameId)
        {
            return View("~/Views/Game/GamesPage.cshtml");
        }
    }
}