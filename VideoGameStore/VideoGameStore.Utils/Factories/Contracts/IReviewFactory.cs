using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoGameStore.Data.Models;

namespace VideoGameStore.Utils.Factories.Contracts
{
    public interface IReviewFactory
    {
        Review Create(string comment, ApplicationUser user, Game game);
    }
}
