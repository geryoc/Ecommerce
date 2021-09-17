using Ecommerce.WebApi.Services.Category.Entities;
using System.ComponentModel.DataAnnotations;

namespace Ecommerce.WebApi.Services.Category.Models
{
    public class CreateCategoryModel
    {
        [StringLength(CategoryConstraints.NameMaxLength, MinimumLength = 1)]
        [Required]
        public string Name { get; set; }
    }
}
