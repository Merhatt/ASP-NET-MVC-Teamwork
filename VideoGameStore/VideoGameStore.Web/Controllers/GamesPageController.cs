using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VideoGameStore.Data.Models;
using VideoGameStore.Services;
using VideoGameStore.Services.Contracts;
using VideoGameStore.Web.Models;
using VideoGameStore.Web.Models.Factories.Contracts;

namespace VideoGameStore.Web.Controllers
{
    public class GamesPageController : Controller
    {
        private IGameServices gameServices;
        private ICategoryServices categoryServices;
        private ICheckBoxModelFactory checkBoxCategoryModelFactory;
        private IGamesPageViewModelFactory gamesPageViewModelFactory;
        private IUserServices userServices;

        public GamesPageController(IGameServices gameServices, ICategoryServices categoryServices, 
            ICheckBoxModelFactory checkBoxCategoryModelFactory, IUserServices userServices,
            IGamesPageViewModelFactory gamesPageViewModelFactory)
        {
            if (gameServices == null)
            {
                throw new NullReferenceException("gameServices cannot be null");
            }

            if (categoryServices == null)
            {
                throw new NullReferenceException("categoryServices cannot be null");
            }

            if (checkBoxCategoryModelFactory == null)
            {
                throw new NullReferenceException("checkBoxCategoryModelFactory cannot be null");
            }

            if (gamesPageViewModelFactory == null)
            {
                throw new NullReferenceException("gamesPageViewModelFactory cannot be null");
            }

            if (userServices == null)
            {
                throw new NullReferenceException("userServices cannot be null");
            }

            this.gameServices = gameServices;
            this.categoryServices = categoryServices;
            this.checkBoxCategoryModelFactory = checkBoxCategoryModelFactory;
            this.gamesPageViewModelFactory = gamesPageViewModelFactory;
            this.userServices = userServices;
        }

        [HttpGet]
        public ActionResult Index()
        {
            GamesPageViewModel model = GetDefaultModel();

            return View("~/Views/Game/GamesPage.cshtml", model);
        }

        [HttpPost]
        public ActionResult Search(GamesPageViewModel model)
        {
            bool isSearchEmpty = string.IsNullOrEmpty(model.SearchName);

            ICollection<Category> categories = new List<Category>();

            foreach (var cat in model.CheckBoxesCategories)
            {
                if (cat.Checked)
                {
                    Category categoryToAdd = this.categoryServices.GetById(cat.Id);

                    categories.Add(categoryToAdd);
                }
            }

            bool isCategoryEmpty = categories.Count() == 0;

            if (isSearchEmpty == false && isCategoryEmpty == false)
            {
                model.Games = this.gameServices.GetAll(categories, model.SearchName);
            }
            else if (isSearchEmpty == false)
            {
                model.Games = this.gameServices.GetAll(model.SearchName);
            }
            else if (isCategoryEmpty == false)
            {
                model.Games = this.gameServices.GetAll(categories);
            }
            else
            {
                model.Games = this.gameServices.GetAll();
            }

            return View("~/Views/Game/GamesPage.cshtml", model);
        }

        [Authorize]
        [HttpPost]
        public ActionResult AddToCart(int gameId)
        {
            Game game = this.gameServices.GetById(gameId);

            if (game == null)
            {
                return HttpNotFound();
            }

            ApplicationUser user = this.userServices.GetUser(this.User.Identity.Name);

            this.userServices.AddGameToCart(user, game);

            GamesPageViewModel model = GetDefaultModel();

            model.IsSuccessActive = true;
            model.SuccesMessage = "Game added to the cart.";

            return View("~/Views/Game/GamesPage.cshtml", model);
        }

        private GamesPageViewModel GetDefaultModel()
        {
            IEnumerable<Game> allGames = this.gameServices.GetAll();

            GamesPageViewModel model = this.gamesPageViewModelFactory.Create(allGames);

            IEnumerable<Category> allCategories = this.categoryServices.GetAll();

            IList<CheckBoxModel> checkBoxes = new List<CheckBoxModel>();

            foreach (var category in allCategories)
            {
                CheckBoxModel categoryToAdd = this.checkBoxCategoryModelFactory.Create(category.Id, category.Name);

                checkBoxes.Add(categoryToAdd);
            }

            model.CheckBoxesCategories = checkBoxes;

            return model;
        }
    }
}