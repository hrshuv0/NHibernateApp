using Entities;

namespace Services;

public interface IProductRepository
{
    Task Create(Product product);
    Task Update(Product product);
    Task Delete(Product product);
    Task<Product> GetById(long id);
    Task<IList<Product>> GetAll();


}