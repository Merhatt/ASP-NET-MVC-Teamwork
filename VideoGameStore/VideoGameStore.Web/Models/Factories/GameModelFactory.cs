using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VideoGameStore.Web.Models.Factories.Contracts;

namespace VideoGameStore.Web.Models.Factories
{
    public class GameModelFactory : IGameModelFactory
    {
        public GameModel Create(int id, string name, decimal price, string description, string imageUrl, IEnumerable<string> categories, IEnumerable<string> platforms)
        {
            if (id < 0)
            {
                throw new NullReferenceException("id cannot be less than 0");
            }

            if (string.IsNullOrEmpty(name))
            {
                throw new NullReferenceException("name cannot be null");
            }

            if (price <= 0)
            {
                throw new NullReferenceException("price cannot be less than 0");
            }

            if (string.IsNullOrEmpty(description))
            {
                throw new NullReferenceException("description cannot be null");
            }

            if (string.IsNullOrEmpty(imageUrl))
            {
                throw new NullReferenceException("imageUrl cannot be null");
            }

            if (categories == null)
            {
                throw new NullReferenceException("categories cannot be null");
            }

            if (platforms == null)
            {
                throw new NullReferenceException("platforms cannot be null");
            }

            GameModel model = new GameModel();

            model.Id = id;
            model.Name = name;
            model.Price = price;
            model.Description = description;
            model.ImageUrl = imageUrl;
            model.Categories = categories;
            model.Platforms = platforms;

            return model;
        }
    }
}