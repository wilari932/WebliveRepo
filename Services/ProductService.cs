using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Domain;
using Microsoft.EntityFrameworkCore;
using Repository;
using Services.Models.ProductModels;

namespace Services
{
    public class ProductService : IProductService
    {
        protected readonly IGenericRepository<Product> _ProductRepository;
        protected readonly IGenericRepository<Category> _CategoryRepository;
        protected readonly IUnitofWork _unitofWork;
        public ProductService(IGenericRepository<Product> product, IGenericRepository<Category> category, IUnitofWork unitofWork)
        {
            _ProductRepository = product;
            _CategoryRepository = category;
            _unitofWork = unitofWork;
        }
        public async Task<Product> CrearProductoAsync(ProductModel product)
        {
            var category = await _CategoryRepository.GetAsync(x => x.CategoryName.ToLower().Equals(product.Category.ToLower()));

            if (category is null)
                category = new Category { CategoryName = product.Category };

            var result = await _ProductRepository.CreateAsync(new Product
            {
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                Category = category,
                Isavalible = true,
            }) ;
             await _unitofWork.CommitAsync();
            return result;
        }

      public async  Task<ICollection<ProductModel>> MostrasProductosAsync()
        {
            var result = await _ProductRepository.GetAllAsync(x => x.Name != null, nameof(Product.Category));
            return result.Select(x => new ProductModel { Category = x.Category.CategoryName
                , Description = x.Description,Name= x.Name, Price = x.Price, Id= x?.Id.ToString()  }).ToList();
        }
    }
}
