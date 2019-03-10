using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdminCRUD_03_March_2019.Models
{
    public class GalleryItem
    {
        public int Id { get; set; }

        [StringLength(300)]
        public string Image { get; set; }

        [Required(ErrorMessage = "Tag is required.")]
        [StringLength(100, ErrorMessage = "Maximum length size 100 charactesr.")]
        public string Tag { get; set; }

        [NotMapped]
        public HttpPostedFileBase Photo { get; set; }
    }
}