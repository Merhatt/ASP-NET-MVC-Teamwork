using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoGameStore.Data.Contracts;
using VideoGameStore.Data.Models;
using VideoGameStore.Services.Contracts;
using VideoGameStore.Utils.Factories.Contracts;

namespace VideoGameStore.Services
{
    public class GameServices : IGameServices
    {
        private IGameFactory gameFactory;
        private IRepository<Game> repository;
        private IUnitOfWork unitOfWork;

        public GameServices(IRepository<Game> repository, IUnitOfWork unitOfWork, IGameFactory gameFactory)
        {
            if (repository == null)
            {
                throw new NullReferenceException("repository cannot be null");
            }

            if (unitOfWork == null)
            {
                throw new NullReferenceException("unitOfWork cannot be null");
            }

            if (gameFactory == null)
            {
                throw new NullReferenceException("gameFactory cannot be null");
            }

            this.repository = repository;
            this.unitOfWork = unitOfWork;
            this.gameFactory = gameFactory;
        }

        public void Create(string name, decimal price, string description, string imageUrl, ICollection<Category> categories)
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

            Game game = this.gameFactory.Create(name, price, description, imageUrl, categories);

            this.repository.Add(game);
            this.unitOfWork.Commit();
        }

        public IEnumerable<Game> GetAll()
        {
            return this.repository.All();
        }

        public IEnumerable<Game> GetAll(IEnumerable<Category> categories)
        {
            if (categories == null || categories.Count() == 0)
            {
                throw new NullReferenceException("categories cannot be null");
            }

            IEnumerable<Game> allGames = GetAll();

            ICollection<Game> allGamesWithCategories = new HashSet<Game>();

            foreach (Game game in allGames)
            {
                bool areAllCategoriesMatching = true;

                foreach (Category category in categories)
                {
                    if (game.Categories.FirstOrDefault(x => x.Name == category.Name) == null)
                    {
                        areAllCategoriesMatching = false;
                        break;
                    }
                }

                if (areAllCategoriesMatching)
                {
                    allGamesWithCategories.Add(game);
                }
            }

            return allGamesWithCategories;
        }

        public IEnumerable<Game> GetAll(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new NullReferenceException("name cannot be null or empty");
            }

            IEnumerable<Game> allGames = GetAll()
                .Where(x => x.Name.ToLower().Contains(name.ToLower()) || 
                name.ToLower().Contains(x.Name.ToLower()));
     
            return allGames;
        }

        public IEnumerable<Game> GetAll(IEnumerable<Category> categories, string name)
        {
            if (categories == null || categories.Count() == 0)
            {
                throw new NullReferenceException("categories cannot be null");
            }

            if (string.IsNullOrEmpty(name))
            {
                throw new NullReferenceException("name cannot be null or empty");
            }

            IEnumerable<Game> all = this.GetAll(categories)
                .Where(x => x.Name.ToLower().Contains(name.ToLower()) ||
                name.ToLower().Contains(x.Name.ToLower()));

            return all;
        }
    }
}
