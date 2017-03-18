using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoGameStore.Data.Contracts;
using VideoGameStore.Data.Models;
using VideoGameStore.Utils.Factories.Contracts;

namespace VideoGameStore.Services
{
    public class GameServices
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
    }
}
