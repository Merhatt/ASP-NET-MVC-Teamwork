using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VideoGameStore.Data.Models;
using VideoGameStore.Services.Contracts;
using VideoGameStore.Web.Models;
using VideoGameStore.Web.Models.Factories.Contracts;

namespace VideoGameStore.Web.Controllers
{
    public class ShopingCartController : Controller
    {
        private ICartViewModelFactory cartViewModelFactory;
        private IGameServices gameServices;
        private IUserServices userServices;

        public ShopingCartController(IUserServices userServices, IGameServices gameServices,
            ICartViewModelFactory cartViewModelFactory)
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

            this.userServices = userServices;
            this.cartViewModelFactory = cartViewModelFactory;
            this.gameServices = gameServices;
        }

        [HttpGet]
        [Authorize]
        public ActionResult Index()
        {
            ApplicationUser user = this.userServices.GetUser(this.User.Identity.Name);

            CartViewModel model = this.cartViewModelFactory.Create(user.ShopingCart);

            return View("~/Views/ShopingCart/Cart.cshtml", model);
        }

        [HttpPost]
        [Authorize]
        public ActionResult RemoveFromCart(int gameId)
        {
            ApplicationUser user = this.userServices.GetUser(this.User.Identity.Name);

            Game game = this.gameServices.GetById(gameId);

            if (game == null)
            {
                return HttpNotFound();
            }

            this.userServices.RemoveGameFromCart(user, game);

            CartViewModel model = this.cartViewModelFactory.Create(user.ShopingCart);

            return View("~/Views/ShopingCart/Cart.cshtml", model);
        }
    }
}