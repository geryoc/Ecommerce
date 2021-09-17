using Ecommerce.WebApi.Services.Product.Entities;
using Ecommerce.WebApi.Shared.Web.ValidationAttributes;
using System.ComponentModel.DataAnnotations;

namespace Ecommerce.WebApi.Services.Product.Models
{
    public class CreateProductModel
    {
        [StringLength(ProductConstraints.NameMaxLength)]
        [Required]
        public string Name { get; set; }

        [StringLength(ProductConstraints.DescriptionMaxLength)]
        [Required]
        public string Description { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        [Required]
        public decimal Price { get; set; }

        [EntityExists(typeof(Category.Entities.Category))]
        public long CategoryId { get; set; }
    }
}
