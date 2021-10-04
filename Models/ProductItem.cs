using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace E_Commerce.Models
{
    public class ProductItem
    {
        [Key]
        public Guid Id { get; set; }
        [Required(ErrorMessage = "ProductName cannot be null")]
        public string ProductName { get; set; }
        [MaxLength(500)]
        public string Description { get; set; }
        [Required(ErrorMessage = "Price cannot be null")]
        public decimal Price { get; set; }
        public bool IsInStock {
            get { return QtyAvailable > 0 ? true : false; }
        }
        [Range(1, 9999, ErrorMessage = "QtyAvailable must between 1 and 9999")]
        public int QtyAvailable { get; set; }
        [ForeignKey("CategoryId")]
        public Guid CategoryId { get; set; }
        public Category Category { get; set; }
        [Range(0.1, 0.99)]
        public double SalePercetage { get; set; }
        [Range(1,5)]
        public int Ratings { get; set; }
        public string Badge { get; set; }



        public IEnumerable<Review> Reviews { get; set; }
        public IEnumerable<ProductImage> Images { get; set; }
    }
}
