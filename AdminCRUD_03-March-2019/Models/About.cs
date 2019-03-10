using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdminCRUD_03_March_2019.Models
{
    public class About
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Title is required.")]
        [StringLength(100,ErrorMessage ="Maximum string length 100 characters.")]
        public string Title { get; set; }

        [Required(ErrorMessage ="Description is required.")]
        [StringLength(1000, ErrorMessage = "Maximum string length 1000 characters.")]
        public string Description { get; set; }

        [StringLength(300)]
        public string Image { get; set; }

        [NotMapped]
        public HttpPostedFileBase Photo { get; set; }
    }
}