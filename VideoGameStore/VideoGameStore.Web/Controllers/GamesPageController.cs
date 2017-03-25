using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VideoGameStore.Data.Models;
using VideoGameStore.Services;
using VideoGameStore.Services.Contracts;
using VideoGameStore.Utils.Factories.Contracts;
using VideoGameStore.Web.Models;
using VideoGameStore.Web.Models.Factories.Contracts;

namespace VideoGameStore.Web.Controllers
{
    public class GamesPageController : Controller
    {
        private const int GamePageCount = 10;

        private IGameServices gameServices;
        private ICategoryServices categoryServices;
        private ICheckBoxModelFactory checkBoxCategoryModelFactory;
        private IGamesPageViewModelFactory gamesPageViewModelFactory;
        private IUserServices userServices;
        private IPageServiceFactory<Game> pageServiceFactory;
        private IGameModelFactory gameModelFactory;

        public GamesPageController(IGameServices gameServices, ICategoryServices categoryServices, 
            ICheckBoxModelFactory checkBoxCategoryModelFactory, IUserServices userServices,
            IGamesPageViewModelFactory gamesPageViewModelFactory, IPageServiceFactory<Game> pageServiceFactory,
            IGameModelFactory gameModelFactory)
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

            if (pageServiceFactory == null)
            {
                throw new NullReferenceException("pageServiceFactory cannot be null");
            }

            if (gameModelFactory == null)
            {
                throw new NullReferenceException("gameModelFactory cannot be null");
            }

            this.gameServices = gameServices;
            this.categoryServices = categoryServices;
            this.checkBoxCategoryModelFactory = checkBoxCategoryModelFactory;
            this.gamesPageViewModelFactory = gamesPageViewModelFactory;
            this.userServices = userServices;
            this.pageServiceFactory = pageServiceFactory;
            this.gameModelFactory = gameModelFactory;
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

            bool isSearchActive = true;

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
                isSearchActive = false;
            }

            model.IsSearchPage = isSearchActive;

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

        [HttpGet]
        public ActionResult GetGamesOnPage(int page = 1)
        {
            GamesPageViewModel model = GetDefaultModel(page);

            ICollection<GameModel> gamesToReturn = new HashSet<GameModel>();

            foreach (var game in model.Games)
            {
                GameModel gameToAdd = this.gameModelFactory.Create(game.Id,
                    game.Name, game.Price, game.Description, game.ImageUrl, game.Categories.Select(x => x.Name).ToList(),
                    game.SupportedPlatforms.Select(x => x.Name).ToList());

                gamesToReturn.Add(gameToAdd);
            }

            return Json(new { games = gamesToReturn, isAuthenticated = User.Identity.IsAuthenticated }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult GetPagesCount()
        {
            IEnumerable<Game> allGames = this.gameServices.GetAll();

            int maxPage = this.pageServiceFactory.Create(allGames, GamePageCount)
                .GetMaxPage();

            return Json(maxPage, JsonRequestBehavior.AllowGet);
        }

        private GamesPageViewModel GetDefaultModel(int page = 1)
        {
            if (page < 1)
            {
                page = 1;
            }

            IEnumerable<Game> allGames = this.gameServices.GetAll();

            int maxPages = this.pageServiceFactory
                .Create(allGames, GamePageCount).GetMaxPage();

            if (page > maxPages)
            {
                page = maxPages;
            }

            allGames = this.pageServiceFactory
                .Create(allGames, GamePageCount)
                .GetPage(page);

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