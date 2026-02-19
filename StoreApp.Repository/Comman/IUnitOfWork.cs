using StoreApp.Repository.Repositories;

namespace StoreApp.Repository.Comman;

public interface IUnitOfWork
{
    ICategoryRepository CategoryRepository { get; }
    IProductRepository ProductRepository { get; }
    Task SaveChangesAsync();
}
