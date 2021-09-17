using Ecommerce.WebApi.Services.Category.Models;
using Ecommerce.WebApi.Shared.Database;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.WebApi.Services.Category
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly DatabaseContext _database;

        public CategoryController(DatabaseContext databaseContext)
        {
            _database = databaseContext;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryModel>>> Search([FromQuery] SearchCategoryModel model)
        {
            var categories = await _database
                .Categories
                .Where(category => string.IsNullOrEmpty(model.Name) || category.Name.Equals(model.Name))
                .ToListAsync();

            return categories.Adapt<List<CategoryModel>>();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryModel>> SearchById([FromRoute] SearchCategoryByIdModel model)
        {
            var category = await _database.Categories.FindAsync(model.Id);

            if (category == null)
            {
                return NotFound();
            }

            return category.Adapt<CategoryModel>();
        }

        [HttpPost]
        public async Task<ActionResult<CategoryModel>> Create([FromBody] CreateCategoryModel model)
        {
            var category = model.Adapt<Entities.Category>();
            _database.Categories.Add(category);
            await _database.SaveChangesAsync();
            return category.Adapt<CategoryModel>();
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult<CategoryModel>> Update([FromRoute] long id, [FromBody] UpdateCategoryModel model)
        {
            var category = await _database.Categories.FindAsync(id);

            if (category == null)
            {
                return NotFound();
            }

            category.Name = model.Name ?? category.Name;
            await _database.SaveChangesAsync();

            return category.Adapt<CategoryModel>();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete([FromRoute] DeleteCategoryModel model)
        {
            var category = await _database.Categories.FindAsync(model.Id);

            if (category == null)
            {
                return NotFound();
            }

            _database.Categories.Remove(category);
            await _database.SaveChangesAsync();

            return Ok();
        }
    }
}
