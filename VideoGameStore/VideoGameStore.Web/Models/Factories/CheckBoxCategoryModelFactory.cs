using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VideoGameStore.Web.Models.Factories.Contracts;

namespace VideoGameStore.Web.Models.Factories
{
    public class CheckBoxCategoryModelFactory : ICheckBoxCategoryModelFactory
    {
        public CheckBoxCategoryModel Create(int id, string name)
        {
            if (id < 0)
            {
                throw new NullReferenceException("Id cannot be less than 0");
            }

            if (string.IsNullOrEmpty(name))
            {
                throw new NullReferenceException("name cannot be null");
            }

            CheckBoxCategoryModel model = new CheckBoxCategoryModel();

            model.Id = id;
            model.Name = name;

            return model;
        }
    }
}