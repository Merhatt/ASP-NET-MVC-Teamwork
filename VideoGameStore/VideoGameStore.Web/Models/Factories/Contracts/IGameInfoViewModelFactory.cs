using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VideoGameStore.Web.Models.Factories.Contracts
{
    public interface IGameInfoViewModelFactory
    {
        GameInfoViewModel Create(int id, string name, decimal price, string description,
            string imageUrl, IEnumerable<CheckBoxModel> categories,
            IEnumerable<SuportedPlatformModel> suportedPlatforms,
            IEnumerable<ReviewModel> reviews);
    }
}