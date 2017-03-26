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
        private ICheckBoxModelFactory checkBoxCategoryModelFactory;
        private IGameInfoViewModelFactory gameInfoViewModelFactory;
        private IGameServices gameServices;
        private IReviewModelFactory reviewModelFactory;
        private ISuportedPlatformModelFactory suportedPlatformModelFactory;
        private IReviewServices reviewServices;
        private IUserServices userServices;

        public GameInfoController(IGameServices gameServices, IUserServices userServices, 
            IReviewServices reviewServices, IGameInfoViewModelFactory gameInfoViewModelFactory, 
            ICheckBoxModelFactory checkBoxCategoryModelFactory, ISuportedPlatformModelFactory suportedPlatformModelFactory,
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

            if (userServices == null)
            {
                throw new NullReferenceException("userServices cannot be null");
            }

            if (reviewServices == null)
            {
                throw new NullReferenceException("reviewServices cannot be null");
            }

            this.gameServices = gameServices;
            this.gameInfoViewModelFactory = gameInfoViewModelFactory;
            this.checkBoxCategoryModelFactory = checkBoxCategoryModelFactory;
            this.suportedPlatformModelFactory = suportedPlatformModelFactory;
            this.reviewModelFactory = reviewModelFactory;
            this.userServices = userServices;
            this.reviewServices = reviewServices;
        }

        [HttpGet]
        public ActionResult Index(int id)
        {
            Game game = this.gameServices.GetById(id);

            if (game == null)
            {
                return RedirectToAction("NotFoundError", "Error");
            }

            ICollection<CheckBoxModel> categories = new HashSet<CheckBoxModel>();

            foreach (var cat in game.Categories)
            {
                CheckBoxModel categoryToAdd = this.checkBoxCategoryModelFactory.Create(cat.Id, cat.Name);

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

        [Authorize]
        [HttpPost]
        public ActionResult AddReview(GameInfoViewModel model)
        {
            Game game = this.gameServices.GetById(model.Id);

            if (game == null || string.IsNullOrEmpty(model.ReviewComment))
            {
                return RedirectToAction("NotFoundError", "Error");
            }

            ApplicationUser user = this.userServices.GetUser(this.User.Identity.Name);

            this.reviewServices.CreateReview(model.ReviewComment, user, game);

            return Redirect(this.Request.UrlReferrer.ToString());
        }
    }
}