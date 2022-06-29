using Microsoft.EntityFrameworkCore;
using TestCrud.Infra.Context;
using TestCrud.Infra.Interfaces;
using TestCrud.Models;
using TestCrud.Models.Dtos;

namespace TestCrud.Infra.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductContext _productContext;

        public ProductRepository(ProductContext context)
        {
            _productContext = context;
        }

        public void Delete(long id)
        {
            var product = _productContext.Products.AsNoTracking().FirstOrDefault(p => p.Id == id);

            if (product != null)
                _productContext.Products.Remove(product);
            else
                throw new Exception();
        }

        public List<Product> GetAll()
        {
            return _productContext.Products.ToList();
        }

        public Product GetById(long id)
        {
            if (id == 0)
                throw new Exception();

            return _productContext.Products.Where(x => x.Id == id).FirstOrDefault();
        }

        public ProductDto Save(ProductSaveDto dto)
        {
            var product = new Product
            {
                Name = dto.Name
            };

            _productContext.Products.Add(product);
            _productContext.SaveChanges();

            return new ProductDto() { Name = product.Name };
        }

        public long Update(Product product)
        {
            _productContext.Products.Update(product);
            return product.Id;
        }
    }
}
