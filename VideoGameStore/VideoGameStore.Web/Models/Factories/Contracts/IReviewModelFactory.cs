using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoGameStore.Web.Models.Factories.Contracts
{
    public interface IReviewModelFactory
    {
        ReviewModel Create(int id, string comment, string userId, string authorName);
    }
}
