using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace E_Commerce.Dtos
{
    public class CategoryCreateDto
    {
        [Required]
        public string CategoryName { get; set; }
    }
}
