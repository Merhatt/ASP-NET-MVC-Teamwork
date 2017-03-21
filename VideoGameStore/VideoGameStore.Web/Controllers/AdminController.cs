using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VideoGameStore.Data.Models;
using VideoGameStore.Services.Contracts;
using VideoGameStore.Web.Models;

namespace VideoGameStore.Web.Controllers
{
    public class AdminController : Controller
    {
        private ICategoryServices categoryServices;
        private IGameServices gameServices;

        public AdminController(ICategoryServices categoryServices, IGameServices gameServices)
        {
            if (categoryServices == null)
            {
                throw new NullReferenceException("categoryServices cannot be null");
            }

            if (gameServices == null)
            {
                throw new NullReferenceException("gameServices cannot be null");
            }

            this.categoryServices = categoryServices;
            this.gameServices = gameServices;
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult AddGame()
        {
            IEnumerable<Category> allCategories = this.categoryServices.GetAll();

            AddGameViewModel model = new AddGameViewModel();

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

            return View("~/Views/Admin/AddGame.cshtml", model);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult AddGame(AddGameViewModel model)
        {
            bool isErrorFound = false;

            if (string.IsNullOrEmpty(model.Name) ||
                model.Name.Length < 3 ||
                model.Name.Length > 100)
            {
                model.ErrorText = "The name of the game must be between 3 and 100 chars";
                isErrorFound = true;
            }
            else if (string.IsNullOrEmpty(model.Description) ||
                model.Description.Length < 10 ||
                model.Description.Length > 1000)
            {
                model.ErrorText = "The description of the game must be between 10 and 1000 chars";
                isErrorFound = true;
            }
            else if (string.IsNullOrEmpty(model.ImageUrl) ||
                model.ImageUrl.Length < 1 ||
                model.ImageUrl.Length > 1000)
            {
                model.ErrorText = "The Image Url must be between 1 and 1000 chars";
                isErrorFound = true;
            }
            else if (model.Price < 0.01m ||
                model.Price > 100000m)
            {
                model.ErrorText = "The price of the game must be between 0.01$ and 100 000$";
                isErrorFound = true;
            }
            else
            {
                int categoriesCount = model.CheckBoxes.Where(x => x.Checked)
                    .Count();

                if (categoriesCount == 0)
                {
                    model.ErrorText = "Atleast 1 category must be chosen";
                    isErrorFound = true;
                }
            }

            if (isErrorFound)
            {
                return View("~/Views/Admin/AddGame.cshtml", model);
            }
            else
            {
                ICollection<Category> categories = new List<Category>();

                foreach (var cat in model.CheckBoxes)
                {
                    if (cat.Checked)
                    {
                        Category categoryToAdd = this.categoryServices.GetById(cat.Id);

                        categories.Add(categoryToAdd);
                    }
                }

                gameServices.Create(model.Name, model.Price, model.Description, model.ImageUrl, categories);

                return RedirectToAction("Index", "GamesPage");
            }
        }
    }
}