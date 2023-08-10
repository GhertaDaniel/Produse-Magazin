using MediatR;

namespace Produse_Magazin.Commands
{
    public record DeleteProductCommand(int id) : IRequest;
}
