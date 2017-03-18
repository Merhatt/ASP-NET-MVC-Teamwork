using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoGameStore.Data.Models
{
    public class ShopCart
    {
        private ICollection<Game> games;

        public ShopCart()
        {
            this.games = new HashSet<Game>();
        }

        public int Id { get; set; }

        public ICollection<Game> Games
        {
            get
            {
                return this.games;
            }
            set
            {
                this.games = value;
            }
        }
    }
}
