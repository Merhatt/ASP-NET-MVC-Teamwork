using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace VideoGameStore.Data.Models
{
    public class ApplicationUser : IdentityUser
    {
        private ICollection<Review> reviews;
        private ICollection<Game> shopingCart;

        public ApplicationUser()
        {
            this.reviews = new HashSet<Review>();
            this.shopingCart = new HashSet<Game>();
        }

        public virtual ICollection<Game> ShopingCart
        {
            get
            {
                return this.shopingCart;
            }
            set
            {
                this.shopingCart = value;
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

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }
}
