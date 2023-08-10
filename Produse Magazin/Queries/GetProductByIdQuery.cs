using MediatR;
using Produse_Magazin.Models;

namespace Produse_Magazin.Queries
{
    public record GetProductByIdQuery(int Id) : IRequest<Product>;
}
