using Ecommerce.WebApi.Shared.Database;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommerce.WebApi.Services.Product.Entities
{
    [Table("Product", Schema = "Ecommerce")]
    public class Product : Entity
    {
        [MaxLength(ProductConstraints.NameMaxLength)]
        [Required]
        public string Name { get; set; }

        [MaxLength(ProductConstraints.DescriptionMaxLength)]
        [Required]
        public string Description { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        [Required]
        public decimal Price { get; set; }

        public long CategoryId { get; set; }
        public Category.Entities.Category Category { get; set; }
    }

    public class ProductConstraints
    {
        public const int NameMaxLength = 300;
        public const int DescriptionMaxLength = 1000;
    }
}
