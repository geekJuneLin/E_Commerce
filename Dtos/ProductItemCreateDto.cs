using E_Commerce.Attributes;
using E_Commerce.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace E_Commerce.Dtos
{
    public class ProductItemCreateDto
    {
        [Required(ErrorMessage = "ProductName cannot be null")]
        public string ProductName { get; set; }
        [Required(ErrorMessage = "Description cannot be null")]
        [MaxLength(500)]
        public string Description { get; set; }
        [Required(ErrorMessage = "Price cannot be null")]
        public decimal Price { get; set; }
        [Required(ErrorMessage = "QtyAvailable cannot be null")]
        [Range(1, 9999, ErrorMessage = "QtyAvailable must between 1 and 9999")]
        public int QtyAvailable { get; set; }
        [ValidGuid]
        public Guid CategoryId { get; set; }
        public int Ratings { get; set; }
        public string Badge { get; set; }
        //public IEnumerable<Review> Reviews { get; set; }
        //public IEnumerable<ProductImage> Images { get; set; }
    }
}
