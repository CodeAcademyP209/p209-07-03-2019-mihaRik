using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AdminCRUD_03_March_2019.Models
{
    public class Pricing
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Title is required.")]
        [StringLength(100, ErrorMessage = "Maximum string length is 100 characters.")]
        public string Title { get; set; }

        [DataType(DataType.Currency, ErrorMessage = "Please enter money value.")]
        public decimal Price { get; set; }

        [Required, DataType(DataType.Time), StringLength(50, ErrorMessage = "Maximum string length 50.")]
        public string Duration { get; set; }

        [Required, StringLength(50, ErrorMessage = "Maximum string length 50.")]
        public string PhotosCount { get; set; }

        [Required, StringLength(50, ErrorMessage = "Maximum string length 50.")]
        public string Place { get; set; }
    }
}