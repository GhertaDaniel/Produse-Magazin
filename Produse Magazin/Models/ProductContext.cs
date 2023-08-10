using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Produse_Magazin.Models
{
    public class ProductContext : DbContext
    {
        public ProductContext(DbContextOptions<ProductContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<Product> Products { get; set; }

        public async Task AddProduct(Product product)
        {
            Products.Add(product);
            await Task.CompletedTask;
        }

        public async Task<IEnumerable<Product>> GetProducts() => await Task.FromResult(Products);
        public async Task<Product> GetProductById(int id)
        {
            return await Task.FromResult(Products.Single(p => p.Id == id));
        }

        public async Task UpdateProduct(int id, Product updateProduct)
        {
            var product = await Products.FindAsync(id);
            if (product != null)
            {
                product.Name = updateProduct.Name;
                product.Description = updateProduct.Description;
                product.Price = updateProduct.Price;
                await SaveChangesAsync();
            }
        }

        public async Task DeleteProduct(int id)
        {
            var product = await Products.FindAsync(id);
            Products.Remove(product);
            await SaveChangesAsync();
        }
    }
}
