using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VideoGameStore.Data.Models;
using VideoGameStore.Services.Contracts;
using VideoGameStore.Utils.Factories.Contracts;
using VideoGameStore.Utils.Pagings.Contracts;
using VideoGameStore.Web.Models;
using VideoGameStore.Web.Models.Factories.Contracts;

namespace VideoGameStore.Web.Controllers
{
    public class ShopingCartController : Controller
    {
        private const int GamesPerPage = 10;

        private ICartViewModelFactory cartViewModelFactory;
        private IGameServices gameServices;
        private IPageServiceFactory<Game> pageServiceFactory;
        private IUserServices userServices;

        public ShopingCartController(IUserServices userServices, IGameServices gameServices,
            ICartViewModelFactory cartViewModelFactory, IPageServiceFactory<Game> pageServiceFactory)
        {
            if (userServices == null)
            {
                throw new NullReferenceException("userServices cannot be null");
            }

            if (cartViewModelFactory == null)
            {
                throw new NullReferenceException("cartViewModelFactory cannot be null");
            }

            if (gameServices == null)
            {
                throw new NullReferenceException("gameServices cannot be null");
            }

            if (pageServiceFactory == null)
            {
                throw new NullReferenceException("pageServiceFactory cannot be null");
            }

            this.userServices = userServices;
            this.cartViewModelFactory = cartViewModelFactory;
            this.gameServices = gameServices;
            this.pageServiceFactory = pageServiceFactory;
        }

        [HttpGet]
        [Authorize]
        public ActionResult Index(int page = 1)
        {
            CartViewModel model = GetDefaultModel(page);

            return View("~/Views/ShopingCart/Cart.cshtml", model);
        }

        [HttpPost]
        [Authorize]
        public ActionResult PageChange(int page = 1)
        {
            CartViewModel model = GetDefaultModel(page);

            return View("~/Views/ShopingCart/Cart.cshtml", model);
        }

        [HttpPost]
        [Authorize]
        public ActionResult RemoveFromCart(int gameId, int page)
        {
            ApplicationUser user = this.userServices.GetUser(this.User.Identity.Name);

            Game game = this.gameServices.GetById(gameId);

            if (game == null)
            {
                return HttpNotFound();
            }

            this.userServices.RemoveGameFromCart(user, game);

            CartViewModel model = GetDefaultModel(page);

            return View("~/Views/ShopingCart/Cart.cshtml", model);
        }

        private CartViewModel GetDefaultModel(int page = 1)
        {
            ApplicationUser user = this.userServices.GetUser(this.User.Identity.Name);

            IEnumerable<Game> shopingCartGames = user.ShopingCart.ToList();

            int maxPage = this.pageServiceFactory
                .Create(shopingCartGames, GamesPerPage)
                .GetMaxPage();

            if (page < 1)
            {
                page = 1;
            }

            if (page > maxPage)
            {
                page = maxPage;
            }

            shopingCartGames = this.pageServiceFactory
                .Create(shopingCartGames, GamesPerPage)
                .GetPage(page);

            CartViewModel model = this.cartViewModelFactory.Create(shopingCartGames);

            model.MaxPages = maxPage;

            model.PageNow = page;

            return model;
        }
    }
}