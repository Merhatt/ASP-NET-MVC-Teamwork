using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VideoGameStore.Web.Models.Factories.Contracts;

namespace VideoGameStore.Web.Models.Factories
{
    public class ReviewModelFactory : IReviewModelFactory
    {
        private IUserModelFactory userModelFactory;

        public ReviewModelFactory(IUserModelFactory userModelFactory)
        {
            if (userModelFactory == null)
            {
                throw new NullReferenceException("userModelFactory cannot be null");
            }

            this.userModelFactory = userModelFactory;
        }

        public ReviewModel Create(int id, string comment, string userId, string authorName)
        {
            if (id < 0)
            {
                throw new NullReferenceException("id cannot be less than 0");
            }

            if (string.IsNullOrEmpty(comment))
            {
                throw new NullReferenceException("comment cannot be less than 0");
            }

            ReviewModel model = new ReviewModel();

            model.Id = id;
            model.Comment = comment;

            UserModel author = this.userModelFactory.Create(userId, authorName);

            model.Author = author;

            return model;
        }
    }
}