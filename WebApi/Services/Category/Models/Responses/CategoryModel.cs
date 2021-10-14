using System;

namespace Ecommerce.WebApi.Services.Category.Models
{
    public class CategoryModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public DateTimeOffset Created { get; set; }
        public DateTimeOffset? Deleted { get; set; }
        public DateTimeOffset? Updated { get; set; }
    }
}
