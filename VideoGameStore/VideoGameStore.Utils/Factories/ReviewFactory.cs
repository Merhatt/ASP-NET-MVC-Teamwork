using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoGameStore.Data.Models;
using VideoGameStore.Utils.Factories.Contracts;

namespace VideoGameStore.Utils.Factories
{
    public class ReviewFactory : IReviewFactory
    {
        public Review Create(string comment, ApplicationUser user, Game game)
        {
            if (string.IsNullOrEmpty(comment))
            {
                throw new NullReferenceException("comment cannot be null or empty");
            }

            if (user == null)
            {
                throw new NullReferenceException("user cannot be null");
            }

            if (game == null)
            {
                throw new NullReferenceException("game cannot be null");
            }

            Review model = new Review();

            model.Comment = comment;
            model.Game = game;
            model.User = user;

            return model;
        }
    }
}
