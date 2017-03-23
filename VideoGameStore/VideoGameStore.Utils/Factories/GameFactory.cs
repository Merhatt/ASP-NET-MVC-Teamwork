using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoGameStore.Data.Models;
using VideoGameStore.Utils.Factories.Contracts;

namespace VideoGameStore.Utils.Factories
{
    public class GameFactory : IGameFactory
    {
        public Game Create(string name, decimal price, string description, string imageUrl, ICollection<Category> categories, ICollection<Platform> platforms)
        {
            if (name == null)
            {
                throw new NullReferenceException("name cannot be null");
            }

            if (price <= 0)
            {
                throw new ArgumentOutOfRangeException("price cannot be less or equal to zero");
            }

            if (description == null)
            {
                throw new NullReferenceException("description cannot be null");
            }

            if (imageUrl == null)
            {
                throw new NullReferenceException("imageUrl cannot be null");
            }

            if (categories == null || categories.Count == 0)
            {
                throw new NullReferenceException("game categories cannot be null or empty");
            }

            if (platforms == null || platforms.Count == 0)
            {
                throw new NullReferenceException("platforms cannot be null or empty");
            }

            Game game = new Game();
            game.Name = name;
            game.Price = price;
            game.Description = description;
            game.ImageUrl = imageUrl;

            foreach (var cat in categories)
            {
                game.Categories.Add(cat);
            }

            foreach (var plat in platforms)
            {
                game.SupportedPlatforms.Add(plat);
            }

            return game;
        }
    }
}
