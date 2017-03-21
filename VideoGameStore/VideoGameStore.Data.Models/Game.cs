using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoGameStore.Data.Models
{
    public class Game
    {
        private ICollection<Category> categories;
        private ICollection<Platform> supportedPlatforms;
        private ICollection<ShopCart> shopingCarts;

        public Game()
        {
            this.categories = new HashSet<Category>();
            this.supportedPlatforms = new HashSet<Platform>();
            this.shopingCarts = new HashSet<ShopCart>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime DateAdded { get; set; }

        public string ImageUrl { get; set; }

        public ICollection<Category> Categories
        {
            get
            {
                return this.categories;
            }
            set
            {
                this.categories = value;
            }
        }

        public ICollection<Platform> SupportedPlatforms
        {
            get
            {
                return this.supportedPlatforms;
            }
            set
            {
                this.supportedPlatforms = value;
            }
        }

        public ICollection<ShopCart> ShopingCarts
        {
            get
            {
                return this.shopingCarts;
            }
            set
            {
                this.shopingCarts = value;
            }
        }
    }
}

