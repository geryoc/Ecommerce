using Ecommerce.WebApi.Shared.Database.Context;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Ecommerce.WebApi.Services.Category.Application.Update
{
    public class UpdateCategoryHandler : IRequestHandler<UpdateCategoryRequest, UpdateCategoryResponse>
    {
        private DatabaseContext _database;

        public UpdateCategoryHandler(DatabaseContext databaseContext)
        {
            _database = databaseContext;
        }

        public async Task<UpdateCategoryResponse> Handle(UpdateCategoryRequest request, CancellationToken cancellationToken)
        {
            var category = await _database.Categories.FindAsync(request.Id);

            if (category != null)
            {
                category.Name = request.Name ?? category.Name;
                await _database.SaveChangesAsync();
            }

            return new UpdateCategoryResponse { Category = category };
        }
    }
}
