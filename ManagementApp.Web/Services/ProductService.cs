using ManagementApp.Web.Data;
using ManagementApp.Web.Data.Models;
using ManagementApp.Web.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ManagementApp.Web.Services
{
    public class ProductService : IProductService
    {
        private readonly ApplicationDbContext context;

        public ProductService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public void AddProduct(Product product)
        {
            if (product == null) throw new ArgumentException("Cannot add empty product object!");

            context.Products.Add(product);
            context.SaveChanges();
        }

        public void DeleteProduct(int productId)
        {
            var productToDelete = context.Products.Find(productId);

            if (productToDelete == null) throw new ArgumentException($"There is no Product of ID:{productId}, that could be deleted");

            context.Remove(productToDelete);
            context.SaveChanges();
        }

        public Product GetProductById(int productId) => context.Products.FirstOrDefault(product => product.Id == productId);

        public IEnumerable<Product> GetProducts() => context.Products.ToList();

        public void UpdateProduct(Product product)
        {
            var productToUpdate = context.Products.Find(product.Id);

            if (product == null) throw new ArgumentException($"Cannot update Product of ID:{product.Id}");

            productToUpdate.Name = product.Name;
            productToUpdate.Description = product.Description;
            productToUpdate.Price = product.Price;
            productToUpdate.ProductType = product.ProductType;

            context.SaveChanges();
        }
    }
}
