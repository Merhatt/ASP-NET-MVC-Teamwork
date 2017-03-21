using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VideoGameStore.Web.Models
{
    public class AddGameViewModel
    {
        public string ErrorText { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime DateCreated { get; set; }

        public string ImageUrl { get; set; }

        public IList<CheckBoxCategoryModel> CheckBoxes { get; set; }
    }
}