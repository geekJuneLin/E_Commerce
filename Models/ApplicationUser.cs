using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace E_Commerce.Models
{
    public class ApplicationUser : IdentityUser
    {
        public IEnumerable<Order> Orders { get; set; }
    }
}
