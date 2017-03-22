using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoGameStore.Data.Contracts;
using VideoGameStore.Data.Models;

namespace VideoGameStore.Data
{
    public class VideoGameDBContext : IdentityDbContext<ApplicationUser>, IVideoGameDBContext
    {
        public VideoGameDBContext()
            : base("VideoGameDB", throwIfV1Schema: false)
        {
        }

        public IDbSet<Game> Games { get; set; }

        public IDbSet<Category> Categories { get; set; }

        public IDbSet<Platform> Platforms { get; set; }

        public static VideoGameDBContext Create()
        {
            return new VideoGameDBContext();
        }
    }
}
