using Ecommerce.WebApi.Shared.Database;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommerce.WebApi.Services.Category.Entities
{
    [Table("Category", Schema = "Ecommerce")]
    public class Category : Entity
    {
        [MaxLength(CategoryConstraints.NameMaxLength)]
        [Required]
        public string Name { get; set; }
    }

    public static class CategoryConstraints
    {
        public const int NameMaxLength = 300;
    }
}
