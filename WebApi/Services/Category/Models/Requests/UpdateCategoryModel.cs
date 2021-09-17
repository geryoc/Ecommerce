using Ecommerce.WebApi.Services.Category.Entities;
using System.ComponentModel.DataAnnotations;

namespace Ecommerce.WebApi.Services.Category.Models
{
    public class UpdateCategoryModel
    {
        [StringLength(CategoryConstraints.NameMaxLength, MinimumLength = 1)]
        public string Name { get; set; }
    }
}
