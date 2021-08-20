using Ecommerce.WebApi.Services.Category.Domain;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Ecommerce.WebApi.Services.Category.Application.Create
{
    public class CreateCategoryRequest : IRequest<CreateCategoryResponse>
    {
        [StringLength(CategoryConstraints.NameMaxLength, MinimumLength = 1)]
        [Required]
        public string Name { get; set; }
    }
}
