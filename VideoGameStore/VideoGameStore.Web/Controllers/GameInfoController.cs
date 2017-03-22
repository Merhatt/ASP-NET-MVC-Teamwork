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
    public class GameInfoController : Controller
    {
        private ICheckBoxCategoryModelFactory checkBoxCategoryModelFactory;
        private IGameInfoViewModelFactory gameInfoViewModelFactory;
        private IGameServices gameServices;
        private IReviewModelFactory reviewModelFactory;
        private ISuportedPlatformModelFactory suportedPlatformModelFactory;

        public GameInfoController(IGameServices gameServices, IGameInfoViewModelFactory gameInfoViewModelFactory, 
            ICheckBoxCategoryModelFactory checkBoxCategoryModelFactory, ISuportedPlatformModelFactory suportedPlatformModelFactory,
            IReviewModelFactory reviewModelFactory)
        {
            if (gameServices == null)
            {
                throw new NullReferenceException("gameServices cannot be null");
            }

            if (gameInfoViewModelFactory == null)
            {
                throw new NullReferenceException("gameInfoViewModelFactory cannot be null");
            }

            if (checkBoxCategoryModelFactory == null)
            {
                throw new NullReferenceException("checkBoxCategoryModelFactory cannot be null");
            }

            if (suportedPlatformModelFactory == null)
            {
                throw new NullReferenceException("suportedPlatformModelFactory cannot be null");
            }

            if (reviewModelFactory == null)
            {
                throw new NullReferenceException("reviewModelFactory cannot be null");
            }

            this.gameServices = gameServices;
            this.gameInfoViewModelFactory = gameInfoViewModelFactory;
            this.checkBoxCategoryModelFactory = checkBoxCategoryModelFactory;
            this.suportedPlatformModelFactory = suportedPlatformModelFactory;
            this.reviewModelFactory = reviewModelFactory;
        }

        [HttpGet]
        public ActionResult Index(int id)
        {
            Game game = this.gameServices.GetById(id);

            if (game == null)
            {
                return HttpNotFound();
            }

            ICollection<CheckBoxCategoryModel> categories = new HashSet<CheckBoxCategoryModel>();

            foreach (var cat in game.Categories)
            {
                CheckBoxCategoryModel categoryToAdd = this.checkBoxCategoryModelFactory.Create(cat.Id, cat.Name);

                categories.Add(categoryToAdd);
            }

            ICollection<SuportedPlatformModel> supportedPlatforms = new HashSet<SuportedPlatformModel>();

            foreach (var platform in game.SupportedPlatforms)
            {
                SuportedPlatformModel platformToAdd = this.suportedPlatformModelFactory.Create(platform.Id, platform.Name);

                supportedPlatforms.Add(platformToAdd);
            }

            ICollection<ReviewModel> reviews = new HashSet<ReviewModel>();

            foreach (var review in game.Reviews)
            {
                ReviewModel reviewToAdd = this.reviewModelFactory.Create(review.Id, review.Comment, review.User.Id, review.User.UserName);

                reviews.Add(reviewToAdd);
            }

            GameInfoViewModel model = this.gameInfoViewModelFactory.Create(game.Id, game.Name, game.Price,
                game.Description, game.ImageUrl, categories, supportedPlatforms, reviews);

            return View("~/Views/Game/GameInfo.cshtml", model);
        }
    }
}