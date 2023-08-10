using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Produse_Magazin.Commands;
using Produse_Magazin.Models;
using Produse_Magazin.Queries;

namespace Produse_Magazin.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ISender _sender;

        public ProductController(ISender sender)
        {
            _sender = sender;
        }

        [HttpGet]
        public async Task<ActionResult> GetProducts()
        {
            var products = await _sender.Send(new GetProductsQuery());
            return Ok(products);
        }

        [HttpGet("{id:int}", Name = "GetProductById")]
        public async Task<ActionResult> GetProductById(int id)
        {
            var product = await _sender.Send(new GetProductByIdQuery(id));

            return Ok(product);
        }

        [HttpPost]
        public async Task<ActionResult> AddProduct([FromBody] Product product)
        {
            var productToReturn = await _sender.Send(new AddProductCommand(product));
            return CreatedAtRoute("GetProductById", new { Id = product.Id }, productToReturn);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateProduct(int id, Product product)
        {
            await _sender.Send(new UpdateProductCommand(id, product));
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProduct(int id)
        {
            await _sender.Send(new DeleteProductCommand(id));
            return NoContent();
        }

        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        //{
        //    if (_dbContext.Products == null)
        //    {
        //        return NotFound();
        //    }

        //    return await _dbContext.Products.ToListAsync();
        //}

        //[HttpGet("{id}")]
        //public async Task<ActionResult<Product>> GetProduct(int id)
        //{
        //    if (_dbContext.Products == null)
        //    {
        //        return NotFound();
        //    }
        //    var product = await _dbContext.Products.FindAsync(id);

        //    if (product == null)
        //    {
        //        return NotFound();
        //    }
        //    return product;
        //}

        //[HttpPost]
        //public async Task<ActionResult<Product>> CreateProduct(Product product)
        //{
        //    _dbContext.Products.Add(product);
        //    await _dbContext.SaveChangesAsync();
        //    return CreatedAtAction(nameof(GetProduct), new { id = product.Id }, product);
        //}

        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutProduct(int id, Product product)
        //{
        //    if (id != product.Id)
        //    {
        //        return BadRequest();
        //    }

        //    _dbContext.Entry(product).State = EntityState.Modified;

        //    try
        //    {
        //        await _dbContext.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!ProductExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else throw;
        //    }

        //    return NoContent();
        //}

        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteProduct(int id)
        //{
        //    if (_dbContext.Products == null)
        //    {
        //        return NotFound();
        //    }

        //    var product = await _dbContext.Products.FindAsync(id);
        //    if (product == null)
        //    {
        //        return NotFound();
        //    }

        //    _dbContext.Products.Remove(product);
        //    await _dbContext.SaveChangesAsync();

        //    return NoContent();
        //}

        //private bool ProductExists(int id)
        //{
        //    return (_dbContext.Products?.Any(e => e.Id == id)).GetValueOrDefault();
        //}
    }
}
