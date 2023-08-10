using MediatR;
using Microsoft.EntityFrameworkCore;
using Produse_Magazin.Models;
using Produse_Magazin.Queries;

namespace Produse_Magazin.Handlers
{
    public class GetProductsHandler : IRequestHandler<GetProductsQuery, IEnumerable<Product>>
    {
        private readonly ProductContext _context;
        public GetProductsHandler(ProductContext context) => _context = context;
        public async Task<IEnumerable<Product>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            return await _context.GetProducts();
        }
    }
}
