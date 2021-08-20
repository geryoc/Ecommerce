using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Ecommerce.WebApi.Services.Category.Application.Delete
{
    public class DeleteCategoryRequest : IRequest<DeleteCategoryResponse>
    {
        [Required]
        public long Id { get; set; }
    }
}
