using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VideoGameStore.Web.Models
{
    public class GameInfoViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public string ReviewComment { get; set; }

        public IEnumerable<CheckBoxModel> Categories { get; set; }

        public IEnumerable<SuportedPlatformModel> SuportedPlatforms { get; set; }

        public IEnumerable<ReviewModel> Reviews { get; set; }

        public IEnumerable<CheckBoxModel> Platforms { get; set; }
    }
}