using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VideoGameStore.Web.Models
{
    public class ReviewModel
    {
        public int Id { get; set; }

        public string Comment { get; set; }

        public UserModel Author { get; set; }
    }
}