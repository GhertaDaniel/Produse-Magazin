using MediatR;
using Produse_Magazin.Models;

namespace Produse_Magazin.Queries
{
    public record GetProductsQuery() : IRequest<IEnumerable<Product>>;
}
