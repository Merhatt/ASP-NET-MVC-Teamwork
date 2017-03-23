namespace VideoGameStore.Data.Migrations
{
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<VideoGameDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
            ContextKey = "VideoGameStore.Data.VideoGameDBContext";
        }

        protected override void Seed(VideoGameDBContext context)
        {
            string[] roles = { "Admin", "User" };

            for (int i = 0; i < roles.Length; i++)
            {
                var role = roles[i];
                if (context.Roles.FirstOrDefault(x => x.Name == role) == null)
                {
                    context.Roles.Add(new IdentityRole(roles[i]));
                }
            }

            string[] categories = 
            {
                "Action",
                "FPS",
                "RPG",
                "MMO",
                "Strategy",
                "Multiplayer",
                "Singleplayer"
            };

            for (int i = 0; i < categories.Length; i++)
            {
                var category = categories[i];

                if (context.Categories.FirstOrDefault(x => x.Name == category) == null)
                {
                    context.Categories.Add(new Category() { Name = category });
                }
            }

           string[] platforms =
           {
                "PC",
                "Xbox 360",
                "Xbox One",
                "PS3",
                "PS4",
                "Nintendo Switch"
            };

            for (int i = 0; i < platforms.Length; i++)
            {
                var platform = platforms[i];

                if (context.Platforms.FirstOrDefault(x => x.Name == platform) == null)
                {
                    context.Platforms.Add(new Platform() { Name = platform });
                }
            }

            context.SaveChanges();
        }
    }
}
