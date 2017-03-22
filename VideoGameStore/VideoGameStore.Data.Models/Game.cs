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
        private ICollection<ApplicationUser> users;
        private ICollection<Review> reviews;

        public Game()
        {
            this.categories = new HashSet<Category>();
            this.supportedPlatforms = new HashSet<Platform>();
            this.users = new HashSet<ApplicationUser>();
            this.reviews = new HashSet<Review>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime DateAdded { get; set; }

        public string ImageUrl { get; set; }

        public virtual ICollection<Category> Categories
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

        public virtual ICollection<Platform> SupportedPlatforms
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

        public virtual ICollection<ApplicationUser> Users
        {
            get
            {
                return this.users;
            }
            set
            {
                this.users = value;
            }
        }

        public virtual ICollection<Review> Reviews
        {
            get
            {
                return this.reviews;
            }
            set
            {
                this.reviews = value;
            }
        }
    }
}

