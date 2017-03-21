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
        private ICategoryServices categoryServices;

        public GamesPageController(IGameServices gameServices, ICategoryServices categoryServices)
        {
            if (gameServices == null)
            {
                throw new NullReferenceException("gameServices cannot be null");
            }

            if (categoryServices == null)
            {
                throw new NullReferenceException("categoryServices cannot be null");
            }

            this.gameServices = gameServices;
            this.categoryServices = categoryServices;
        }

        [HttpGet]
        public ActionResult Index()
        {
            GamesPageViewModel model = new GamesPageViewModel();
            model.Games = this.gameServices.GetAll();

            IEnumerable<Category> allCategories = this.categoryServices.GetAll();

            IList<CheckBoxCategoryModel> checkBoxes = new List<CheckBoxCategoryModel>();

            foreach (var category in allCategories)
            {
                checkBoxes.Add(new CheckBoxCategoryModel()
                {
                    Name = category.Name,
                    Id = category.Id
                });
            }

            model.CheckBoxes = checkBoxes;

            return View("~/Views/Game/GamesPage.cshtml", model);
        }

        [HttpPost]
        public ActionResult SearchByName(GamesPageViewModel model)
        {
            bool isSearchEmpty = string.IsNullOrEmpty(model.SearchName);

            ICollection<Category> categories = new List<Category>();

            foreach (var cat in model.CheckBoxes)
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
            return View("~/Views/Game/GamesPage.cshtml");
        }
    }
}