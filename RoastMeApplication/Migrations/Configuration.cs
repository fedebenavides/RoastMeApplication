namespace RoastMeApplication.Migrations
{
    using Models.Entities;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<RoastMeApplication.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(RoastMeApplication.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.
            //context.Participants.Add(new Participant("admin", "admin", "admin@abc.com"));

        }
    }
}
