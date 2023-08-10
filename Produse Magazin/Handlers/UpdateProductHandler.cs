using MediatR;
using Produse_Magazin.Commands;
using Produse_Magazin.Models;

namespace Produse_Magazin.Handlers
{
    public class UpdateProductHandler : IRequestHandler<UpdateProductCommand>
    {
        private readonly ProductContext _productContext;

        public UpdateProductHandler(ProductContext productContext) => _productContext = productContext;

        public async Task Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            await _productContext.UpdateProduct(request.id, request.product);
        }
    }
}
