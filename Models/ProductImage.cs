using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace E_Commerce.Models
{
    public class ProductImage
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "ImageUrl cannot be null")]
        public string ImageUrl { get; set; }
    }
}
