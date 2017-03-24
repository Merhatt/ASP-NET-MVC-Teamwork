using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using VideoGameStore.Data.Models;

namespace VideoGameStore.Web.Models
{
    public class GamesPageViewModel
    {
        public string SearchName { get; set; }

        public IEnumerable<Game> Games { get; set; }

        public IList<CheckBoxModel> CheckBoxesCategories { get; set; }

        public string SuccesMessage { get; set; }

        public bool IsSuccessActive { get; set; }
    }
}