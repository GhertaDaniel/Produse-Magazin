using MediatR;
using Produse_Magazin.Commands;
using Produse_Magazin.Models;

namespace Produse_Magazin.Handlers
{
    public class AddProductHandler : IRequestHandler<AddProductCommand, Product>
    {
        private readonly ProductContext _Context;

        public AddProductHandler(ProductContext context) => _Context = context;

        public async Task<Product> Handle(AddProductCommand request, CancellationToken cancellationToken)
        {
            await _Context.AddProduct(request.Product);
            await _Context.SaveChangesAsync();
            return request.Product;
        }
    }
}
