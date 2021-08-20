using Ecommerce.WebApi.Shared.Database.Context;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Ecommerce.WebApi.Services.Category.Application.Delete
{
    public class DeleteCategoryHandler : IRequestHandler<DeleteCategoryRequest, DeleteCategoryResponse>
    {
        private DatabaseContext _database;

        public DeleteCategoryHandler(DatabaseContext databaseContext)
        {
            _database = databaseContext;
        }

        public async Task<DeleteCategoryResponse> Handle(DeleteCategoryRequest request, CancellationToken cancellationToken)
        {
            var category = await _database.Categories.FindAsync(request.Id);

            if (category != null)
            {
                _database.Categories.Remove(category);
                await _database.SaveChangesAsync();
            }

            return new DeleteCategoryResponse { Category = category };
        }
    }
}
