using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace E_Commerce.Models
{
    public class Order
    {
        [Key]
        public Guid Id { get; set; }
        public string Status { get; set; }
        public decimal TotalPrice { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime CreatedTime { get; set; }
        public IEnumerable<ProductItem> ProductItems { get; set; }

    }
}
