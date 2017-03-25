using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VideoGameStore.Data.Models;

namespace VideoGameStore.Web.Models
{
    public class CartViewModel
    {
        public IEnumerable<Game> GamesInCart { get; set; }

        public int PageNow { get; set; }

        public int MaxPages { get; set; }
    }
}