namespace AdminCRUD_03_March_2019.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using AdminCRUD_03_March_2019.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<AdminCRUD_03_March_2019.DAL.OstinPortfolioContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(AdminCRUD_03_March_2019.DAL.OstinPortfolioContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            context.Pricings.AddOrUpdate(p => new { p.Duration, p.Place, p.PhotosCount },
                new Pricing
                {
                    Title="LOVE STORY",
                    Price = 100,
                    Duration = "2 hours",
                    PhotosCount="20-30 photos",
                    Place="Code Academy"
                },
                new Pricing
                {
                    Title="WEDDING",
                    Price = 180,
                    Duration = "2 hours",
                    PhotosCount = "80-100 photos",
                    Place = "Ehmedli"
                },
                new Pricing
                {
                    Title="PORTRAITS",
                    Price = 250,
                    Duration = "1 hours",
                    PhotosCount = "30-40 photos",
                    Place = "Razin"
                });
        }
    }
}