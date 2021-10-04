using E_Commerce.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace E_Commerce.Dtos
{
    public class ProductItemUpdateDto
    {
        public string ProductName { get; set; }
        [MaxLength(500)]
        public string Description { get; set; }
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }
        
        [Range(1, 9999, ErrorMessage = "QtyAvailable must between 1 and 9999")]
        public int QtyAvailable { get; set; }
        public CategoryDto Category { get; set; }
        //public IEnumerable<Review> Reviews { get; set; }
        //public IEnumerable<ProductImage> Images { get; set; }
    }
}
