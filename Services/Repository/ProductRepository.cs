using Entities;
using NHibernate;

namespace Services.Repository;

public class ProductRepository : IProductRepository
{
    private readonly ISession _session;

    public ProductRepository(ISession session)
    {
        _session = session;
    }

    public async Task Create(Product product)
    {
        using var transacation = _session.BeginTransaction();

        try
        {
            await _session.SaveAsync(product);
            await transacation.CommitAsync();
        }
        catch(Exception)
        {
            await transacation.RollbackAsync();
            throw;
        }
        finally
        {
            transacation?.Dispose();
        }
    }

    public Task Delete(Product product)
    {
        throw new NotImplementedException();
    }

    public async Task<IList<Product>> GetAll()
    {
        using var transaction = _session.BeginTransaction();

        try
        {
            IQuery sqlQuery = _session.CreateSQLQuery($"select * from Product").AddEntity(typeof(Product));

            IList<Product> productList = await sqlQuery.ListAsync<Product>();

            return productList;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public Task<Product> GetById(long id)
    {
        throw new NotImplementedException();
    }

    public Task Update(Product product)
    {
        throw new NotImplementedException();
    }
}