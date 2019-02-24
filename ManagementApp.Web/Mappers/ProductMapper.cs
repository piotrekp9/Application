using System.Collections.Generic;
using ManagementApp.Web.Data.Models;
using ManagementApp.Web.ViewModel;

namespace ManagementApp.Web.Mappers
{
    public class ProductMapper
    {
        public static ProductViewModel MapToViewModel(Product product)
        {
            return new ProductViewModel()
            {
                Id = product.Id,
                Description = product.Description,
                Name = product.Name,
                Price = product.Price,
                QualificationType = product.QualificationType
            };
        }

        public static IEnumerable<ProductViewModel> MapManyToViewModel(IEnumerable<Product> products)
        {
            var list = new List<ProductViewModel>();

            foreach (var product in products)
            {
                list.Add(MapToViewModel(product));
            }

            return list;
        }

        public static Product MapToDomainModel(ProductViewModel product)
        {
            return new Product()
            {
                Description = product.Description,
                Name = product.Name,
                Price = product.Price,
                QualificationType = product.QualificationType
            };
        }
    }
}
