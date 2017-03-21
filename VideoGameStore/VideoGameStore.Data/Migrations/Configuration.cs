namespace VideoGameStore.Data.Migrations
{
    using Microsoft.AspNet.Identity.EntityFramework;
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
        }
    }
}
