using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VideoGameStore.Web.Models.Factories.Contracts;

namespace VideoGameStore.Web.Models.Factories
{
    public class GameInfoViewModelFactory : IGameInfoViewModelFactory
    {
        public GameInfoViewModel Create(int id, string name, decimal price, string description, string imageUrl, IEnumerable<CheckBoxCategoryModel> categories, IEnumerable<SuportedPlatformModel> suportedPlatforms, IEnumerable<ReviewModel> reviews)
        {
            if (id < 0)
            {
                throw new NullReferenceException("Id cannot be less than 0");
            }

            if (string.IsNullOrEmpty(name))
            {
                throw new NullReferenceException("name cannot be null or empty");
            }

            if (price < 0)
            {
                throw new NullReferenceException("price cannot be less than 0");
            }

            if (string.IsNullOrEmpty(description))
            {
                throw new NullReferenceException("description cannot be null or empty");
            }

            if (string.IsNullOrEmpty(imageUrl))
            {
                throw new NullReferenceException("imageUrl cannot be null or empty");
            }

            if (categories == null)
            {
                throw new NullReferenceException("categories cannot be null");
            }

            if (suportedPlatforms == null)
            {
                throw new NullReferenceException("suportedPlatforms cannot be null");
            }

            if (reviews == null)
            {
                throw new NullReferenceException("reviews cannot be null");
            }

            GameInfoViewModel model = new GameInfoViewModel();

            model.Id = id;
            model.Name = name;
            model.Description = description;
            model.Price = price;
            model.Reviews = reviews;
            model.ImageUrl = imageUrl;
            model.SuportedPlatforms = suportedPlatforms;
            model.Categories = categories;

            return model;
        }
    }
}