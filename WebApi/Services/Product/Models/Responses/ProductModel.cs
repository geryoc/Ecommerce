namespace Ecommerce.WebApi.Services.Product.Models
{
    public class ProductModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public Category.Models.CategoryModel Category { get; set; }
    }
}
