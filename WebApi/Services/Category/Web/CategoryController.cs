using Ecommerce.WebApi.Services.Category.Application.Create;
using Ecommerce.WebApi.Services.Category.Application.Delete;
using Ecommerce.WebApi.Services.Category.Application.GetById;
using Ecommerce.WebApi.Services.Category.Application.Search;
using Ecommerce.WebApi.Services.Category.Application.Update;
using Mapster;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.WebApi.Services.Category.Web
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryResource>>> Search([FromQuery] SearchCategoryRequest request)
        {
            var response = await _mediator.Send(request);

            var categories = response
                .Categories
                .Select(category => category.Adapt<CategoryResource>())
                .ToList();

            return categories;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryResource>> GetById([FromRoute] GetCategoryByIdRequest request)
        {
            var response = await _mediator.Send(request);

            if (response.Category == null)
            {
                return NotFound();
            }

            return response.Category.Adapt<CategoryResource>();
        }

        [HttpPost]
        public async Task<ActionResult<CategoryResource>> Create([FromBody] CreateCategoryRequest request)
        {
            var response = await _mediator.Send(request);
            return response.Category.Adapt<CategoryResource>();
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult<CategoryResource>> Update([FromRoute] long id, [FromBody] UpdateCategoryRequest request)
        {
            request.Id = id;
            var response = await _mediator.Send(request);

            if (response.Category == null)
            {
                return NotFound();
            }

            return response.Category.Adapt<CategoryResource>();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete([FromRoute] DeleteCategoryRequest request)
        {
            var response = await _mediator.Send(request);

            if (response.Category == null)
            {
                return NotFound();
            }

            return Ok();
        }
    }
}
