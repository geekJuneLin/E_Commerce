using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Commerce.Dtos
{
    public class CategoryDto
    {
        public string CategoryName { get; set; }
        public ICollection<ProductItemDto> ProductItems { get; set; }
    }
}
