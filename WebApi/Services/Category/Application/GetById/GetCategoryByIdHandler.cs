using Ecommerce.WebApi.Shared.Database.Context;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Ecommerce.WebApi.Services.Category.Application.GetById
{
    public class GetCategoryByIdHandler : IRequestHandler<GetCategoryByIdRequest, GetCategoryByIdResponse>
    {
        private DatabaseContext _database;

        public GetCategoryByIdHandler(DatabaseContext database)
        {
            _database = database;
        }

        public async Task<GetCategoryByIdResponse> Handle(GetCategoryByIdRequest request, CancellationToken cancellationToken)
        {
            var category = await _database.Categories.FindAsync(request.Id);
            return new GetCategoryByIdResponse { Category = category };
        }
    }
}
