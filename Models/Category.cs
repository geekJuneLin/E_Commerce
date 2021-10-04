using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace E_Commerce.Models
{
    public class Category
    {
        [Key]
        public Guid CategoryId { get; set; }
        [Required]
        public string CategoryName { get; set; }
        public ICollection<ProductItem> ProductItems { get; set; }
            = new List<ProductItem>();
    }
}
