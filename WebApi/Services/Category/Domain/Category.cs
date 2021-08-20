using Ecommerce.WebApi.Shared.Domain;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommerce.WebApi.Services.Category.Domain
{
    [Table("Category", Schema = "Ecommerce")]
    public class Category : Entity
    {
        [MaxLength(CategoryConstraints.NameMaxLength)]
        [Required]
        public string Name { get; set; }
    }
}
