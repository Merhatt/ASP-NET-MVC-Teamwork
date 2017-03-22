using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VideoGameStore.Web.Models.Factories.Contracts;

namespace VideoGameStore.Web.Models.Factories
{
    public class UserModelFactory : IUserModelFactory
    {
        public UserModel Create(string id, string username)
        {
            if (string.IsNullOrEmpty(id))
            {
                throw new NullReferenceException("id cannot be null");
            }

            if (string.IsNullOrEmpty(username))
            {
                throw new NullReferenceException("username cannot be null");
            }

            UserModel model = new UserModel();

            model.Id = id;
            model.Username = username;

            return model;
        }
    }
}