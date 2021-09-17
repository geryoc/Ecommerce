using System.ComponentModel.DataAnnotations;

namespace Ecommerce.WebApi.Services.Category.Models
{
    public class DeleteCategoryModel
    {
        [Required]
        public long Id { get; set; }
    }
}
