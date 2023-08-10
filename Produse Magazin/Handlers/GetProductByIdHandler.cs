using MediatR;
using Produse_Magazin.Models;
using Produse_Magazin.Queries;

namespace Produse_Magazin.Handlers
{
    public class GetProductByIdHandler : IRequestHandler<GetProductByIdQuery, Product>
    {
        private readonly ProductContext _context;

        public GetProductByIdHandler(ProductContext context) => _context = context;

        public async Task<Product> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            return await _context.GetProductById(request.Id);
        }
    }
}
