using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VideoGameStore.Web.Models
{
    public class CheckBoxCategoryModel
    {
        public CheckBoxCategoryModel()
        {
        }

        /*
        public CheckBoxCategoryModel(string name, int id)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new NullReferenceException("name cannot be null");
            }

            if (id < 0)
            {
                throw new NullReferenceException("id cannot be less than zero");
            }

            this.Name = name;
            this.Id = id;
        }
        */

        public bool Checked { get; set; }

        public string Name { get; set; }

        public int Id { get; set; }
    }
}