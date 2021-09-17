using System;
using System.ComponentModel.DataAnnotations;

namespace Ecommerce.WebApi.Services.Product.Models
{
    public class DeleteProductModel
    {
        [Required]
        [Range(1, long.MaxValue)]
        public long Id { get; set; }
    }
}
