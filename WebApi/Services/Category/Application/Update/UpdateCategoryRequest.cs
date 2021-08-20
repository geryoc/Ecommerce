using Ecommerce.WebApi.Services.Category.Domain;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Ecommerce.WebApi.Services.Category.Application.Update
{
    public class UpdateCategoryRequest : IRequest<UpdateCategoryResponse>
    {
        public long Id { get; set; }

        [StringLength(CategoryConstraints.NameMaxLength, MinimumLength = 1)]
        public string Name { get; set; }
    }
}
