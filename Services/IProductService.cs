using Domain;
using Services.Models.ProductModels;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
  public interface IProductService
    {
        Task<Product>CrearProductoAsync(ProductModel product);
        Task<ICollection<ProductModel>> MostrasProductosAsync();
    }
}
