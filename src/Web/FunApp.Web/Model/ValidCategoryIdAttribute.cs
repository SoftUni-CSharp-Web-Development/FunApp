using System.ComponentModel.DataAnnotations;
using FunApp.Services.DataServices;

namespace FunApp.Services.Models.Jokes
{
    public class ValidCategoryIdAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var service = (ICategoriesService) validationContext
                .GetService(typeof(ICategoriesService));

            if (service.IsCategoryIdValid((int) value))
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult("Invalid category id!");
            }
        }
    }
}