using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoGameStore.Data.Models;

namespace VideoGameStore.Services.Contracts
{
    public interface IReviewServices
    {
        void CreateReview(string comment, ApplicationUser user, Game game);
    }
}
