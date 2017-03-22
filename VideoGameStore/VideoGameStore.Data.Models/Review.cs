using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoGameStore.Data.Models
{
    public class Review
    {
        public Review()
        {
            this.DatePosted = DateTime.Now;
        }

        public int Id { get; set; }

        public string Comment { get; set; }

        public DateTime DatePosted { get; set; }

        public virtual Game Game { get; set; }

        public virtual ApplicationUser User { get; set; }
    }
}
