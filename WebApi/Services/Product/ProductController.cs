using Ecommerce.WebApi.Services.Product.Helpers;
using Ecommerce.WebApi.Services.Product.Models;
using Ecommerce.WebApi.Shared.Database;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.WebApi.Services.Product
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly DatabaseContext _databaseContext;

        public ProductController(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        [HttpGet]
        public async Task<ActionResult<ProductPageModel>> Search([FromQuery] SearchProductModel model)
        {
            var productsQuery = _databaseContext.Products
                .Where(product => model.CategoryId == null || product.CategoryId == model.CategoryId)
                .Where(product => model.Name == null || product.Name.Contains(model.Name))
                .Where(product => model.MinPrice == null || product.Price >= model.MinPrice)
                .Where(product => model.MaxPrice == null || product.Price <= model.MaxPrice)
                .ProductsOrderBy(model.OrderBy);

            var products = await productsQuery
                .Skip(model.Skip)
                .Take(model.Take)
                .Include(product => product.Category)
                .ToListAsync();

            var totalCount = await productsQuery.CountAsync();

            var response = new ProductPageModel
            {
                Products = products.Adapt<List<ProductModel>>(),
                TotalCount = totalCount,
                Skip = model.Skip,
                Take = model.Take
            };

            return response;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductModel>> SearchById([FromRoute] SearchProductByIdModel model)
        {
            var product = await _databaseContext
                .Products
                .Include(p => p.Category)
                .FirstOrDefaultAsync(product => product.Id == model.Id);

            if (product == null)
            {
                return NotFound();
            }

            return product.Adapt<ProductModel>();
        }

        [HttpPost]
        public async Task<ActionResult<ProductModel>> Create([FromBody] CreateProductModel model)
        {
            var product = model.Adapt<Entities.Product>();
            _databaseContext.Products.Add(product);
            await _databaseContext.SaveChangesAsync();
            return product.Adapt<ProductModel>();
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult<ProductModel>> Update([FromRoute] long id, [FromBody] UpdateProductModel model)
        {
            var product = await _databaseContext
                .Products
                .Include(p => p.Category)
                .FirstOrDefaultAsync(product => product.Id == id);

            if (product == null)
            {
                return NotFound();
            }

            product.Name = model.Name ?? product.Name;
            product.Description = model.Description ?? product.Description;
            product.ImageUrl = model.ImageUrl ?? product.ImageUrl;
            product.Price = model.Price ?? product.Price;
            product.CategoryId = model.CategoryId ?? product.CategoryId;

            await _databaseContext.SaveChangesAsync();

            return product.Adapt<ProductModel>();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ProductModel>> Delete([FromRoute] DeleteProductModel model)
        {
            var product = await _databaseContext.Products.FindAsync(model.Id);

            if (product == null)
            {
                return NotFound();
            }

            _databaseContext.Products.Remove(product);
            await _databaseContext.SaveChangesAsync();

            return Ok();
        }
    }
}
