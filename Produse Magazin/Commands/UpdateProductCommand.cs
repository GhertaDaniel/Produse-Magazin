using MediatR;
using Produse_Magazin.Models;

namespace Produse_Magazin.Commands
{
    public record UpdateProductCommand(int id, Product product) : IRequest;
}
