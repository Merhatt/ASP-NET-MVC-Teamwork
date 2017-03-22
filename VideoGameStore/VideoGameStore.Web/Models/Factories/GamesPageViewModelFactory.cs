using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VideoGameStore.Data.Models;
using VideoGameStore.Web.Models.Factories.Contracts;

namespace VideoGameStore.Web.Models.Factories
{
    public class GamesPageViewModelFactory : IGamesPageViewModelFactory
    {
        public GamesPageViewModel Create(IEnumerable<Game> games)
        {
            if (games == null)
            {
                throw new NullReferenceException("games cannot be null");
            }

            GamesPageViewModel model = new GamesPageViewModel();

            model.Games = games;

            return model;
        }
    }
}