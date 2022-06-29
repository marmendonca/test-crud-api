using TestCrud.Models;
using TestCrud.Models.Dtos;

namespace TestCrud.Infra.Interfaces
{
    public interface IProductRepository
    {
        List<Product> GetAll();

        Product GetById(long id);

        ProductDto Save(ProductSaveDto dto);

        long Update(Product product);

        void Delete(long id);
    }
}
