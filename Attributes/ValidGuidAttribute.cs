using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace E_Commerce.Attributes
{
    public class ValidGuidAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var guidIdValue = (Guid)value;
            if (guidIdValue != Guid.Empty)
            {
                return ValidationResult.Success;
            }

            return new ValidationResult("Guid value is not valid");
        }
    }
}
