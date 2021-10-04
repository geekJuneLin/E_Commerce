using E_Commerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Commerce.Dtos
{
    public class ProductItemDto
    {
        public Guid Id { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public bool IsInStock
        {
            get { return QtyAvailable > 0 ? true : false; }
        }
        public int QtyAvailable { get; set; }
        public decimal SalePrice { 
            get {
               return (decimal)(SalePercetage * (double) Price);
            } 
        }
        public double SalePercetage { get; set; }
        public int Ratings { get; set; }
        public string Badge { get; set; }
        public CategoryNameDto Category { get; set; }
        //public IEnumerable<Review> Reviews { get; set; }
        //public IEnumerable<ProductImage> Images { get; set; }
    }
}
