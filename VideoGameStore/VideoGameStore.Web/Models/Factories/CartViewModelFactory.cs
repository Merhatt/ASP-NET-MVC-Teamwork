using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VideoGameStore.Data.Models;
using VideoGameStore.Web.Models.Factories.Contracts;

namespace VideoGameStore.Web.Models.Factories
{
    public class CartViewModelFactory : ICartViewModelFactory
    {
        public CartViewModel Create(IEnumerable<Game> games)
        {
            if (games == null)
            {
                throw new NullReferenceException("games cannot be null");
            }

            CartViewModel model = new CartViewModel();

            model.GamesInCart = games;

            return model;
        }
    }
}