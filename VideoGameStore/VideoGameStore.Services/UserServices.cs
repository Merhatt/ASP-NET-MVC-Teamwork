using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoGameStore.Data.Contracts;
using VideoGameStore.Data.Models;
using VideoGameStore.Services.Contracts;

namespace VideoGameStore.Services
{
    public class UserServices : IUserServices
    {
        private IRepository<ApplicationUser> repository;
        private IUnitOfWork unitOfWork;

        public UserServices(IRepository<ApplicationUser> repository, IUnitOfWork unitOfWork)
        {
            if (repository == null)
            {
                throw new NullReferenceException("repository cannot be null");
            }

            if (unitOfWork == null)
            {
                throw new NullReferenceException("unitOfWork cannot be null");
            }

            this.repository = repository;
            this.unitOfWork = unitOfWork;
        }

        public void AddGameToCart(ApplicationUser user, Game game)
        {
            if (user == null)
            {
                throw new NullReferenceException("user cannot be null");
            }

            if (game == null)
            {
                throw new NullReferenceException("game cannot be null");
            }

            bool isGameInCart = user.ShopingCart
                .FirstOrDefault(x => x.Name == game.Name) != null;

            if (isGameInCart == false)
            {
                user.ShopingCart.Add(game);

                this.unitOfWork.Commit();
            }
        }

        public ApplicationUser GetUser(string username)
        {
            ApplicationUser user = this.repository.All()
                .FirstOrDefault(x => x.UserName == username);

            return user;
        }

        public void RemoveGameFromCart(ApplicationUser user, Game game)
        {
            if (user.ShopingCart.FirstOrDefault(x => x.Id == game.Id) == null)
            {
                return;
            }

            user.ShopingCart.Remove(game);

            this.unitOfWork.Commit();
        }
    }
}
