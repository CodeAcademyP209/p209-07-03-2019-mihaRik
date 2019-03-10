using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using AdminCRUD_03_March_2019.Models;

namespace AdminCRUD_03_March_2019.DAL
{
    public class OstinPortfolioContext : DbContext
    {
        public DbSet<GalleryItem> GalleryItems { get; set; }
        public DbSet<About> Abouts { get; set; }
        public DbSet<Pricing> Pricings { get; set; }
    }
}