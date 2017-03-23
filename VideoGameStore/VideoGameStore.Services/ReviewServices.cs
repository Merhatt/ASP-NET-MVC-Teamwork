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
    public class ReviewServices : IReviewServices
    {
        private IRepository<Review> repository;
        private IReviewFactory reviewFactory;
        private IUnitOfWork unitOfWork;

        public ReviewServices(IRepository<Review> repository, IUnitOfWork unitOfWork, IReviewFactory reviewFactory)
        {
            if (repository == null)
            {
                throw new NullReferenceException("repository cannot be null");
            }

            if (unitOfWork == null)
            {
                throw new NullReferenceException("unitOfWork cannot be null");
            }

            if (reviewFactory == null)
            {
                throw new NullReferenceException("reviewFactory cannot be null");
            }

            this.repository = repository;
            this.reviewFactory = reviewFactory;
            this.unitOfWork = unitOfWork;
        }

        public void CreateReview(string comment, ApplicationUser user, Game game)
        {
            if (string.IsNullOrEmpty(comment))
            {
                throw new NullReferenceException("comment cannot be null");
            }

            if (user == null)
            {
                throw new NullReferenceException("user cannot be null");
            }

            if (game == null)
            {
                throw new NullReferenceException("game cannot be null");
            }

            Review model = this.reviewFactory.Create(comment, user, game);

            this.repository.Add(model);
            this.unitOfWork.Commit();
        }
    }
}
