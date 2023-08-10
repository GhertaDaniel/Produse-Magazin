using MediatR;
using Produse_Magazin.Commands;
using Produse_Magazin.Models;

namespace Produse_Magazin.Handlers
{
    public class DeleteProductHandler : IRequestHandler<DeleteProductCommand>
    {
        private readonly ProductContext _context;

        public DeleteProductHandler(ProductContext context) => _context = context;

        public async Task Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            await _context.DeleteProduct(request.id);
        }
    }
}
