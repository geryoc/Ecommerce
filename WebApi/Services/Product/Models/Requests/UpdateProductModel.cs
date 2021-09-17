using Ecommerce.WebApi.Services.Product.Entities;
using Ecommerce.WebApi.Shared.Web.ValidationAttributes;
using System.ComponentModel.DataAnnotations;

namespace Ecommerce.WebApi.Services.Product.Models
{
    public class UpdateProductModel
    {
        [StringLength(ProductConstraints.NameMaxLength)]
        public string Name { get; set; }

        [StringLength(ProductConstraints.DescriptionMaxLength)]
        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public decimal? Price { get; set; }

        [EntityExists(typeof(Category.Entities.Category))]
        public long? CategoryId { get; set; }
    }
}
