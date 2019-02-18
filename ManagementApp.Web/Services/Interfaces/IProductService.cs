using ManagementApp.Web.Data.Models;
using System.Collections.Generic;

namespace ManagementApp.Web.Services.Interfaces
{
    public interface IProductService
    {
        IEnumerable<Product> GetProducts();
        Product GetProductById(int productId);
        void DeleteProduct(int productId);
        void AddProduct(Product product);
        void UpdateProduct(Product product);
    }
}
