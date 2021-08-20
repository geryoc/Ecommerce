using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Ecommerce.WebApi.Services.Category.Application.GetById
{
    public class GetCategoryByIdRequest : IRequest<GetCategoryByIdResponse>
    {
        [Required]
        public long Id { get; set; }
    }
}
