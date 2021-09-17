using System.ComponentModel.DataAnnotations;

namespace Ecommerce.WebApi.Services.Category.Models
{
    public class SearchCategoryByIdModel
    {
        [Required]
        [Range(1, long.MaxValue)]
        public long Id { get; set; }
    }
}
