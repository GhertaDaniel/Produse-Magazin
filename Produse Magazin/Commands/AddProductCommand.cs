using MediatR;
using Produse_Magazin.Models;

namespace Produse_Magazin.Commands
{
    public record AddProductCommand(Product Product) : IRequest<Product>;
}
