using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdminCRUD_03_March_2019.Models.ViewModels
{
    public class HomeIndexViewModel
    {
        public IEnumerable<GalleryItem> GalleryItem { get; set; }
        public IEnumerable<About> About { get; set; }
        public IEnumerable<Pricing> Pricings { get; set; }
    }
}