using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace E_Commerce.Models
{
    public class Review
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "UserName cannot be null")]
        public string UserName { get; set; }
        public string Rating { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime CreatedTime { get; set; }
        [MaxLength(200)]
        public string ReviewContent { get; set; }
    }
}
