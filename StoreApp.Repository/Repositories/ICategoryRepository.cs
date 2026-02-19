using StoreApp.Domain.Entities;

namespace StoreApp.Repository.Repositories;

public interface ICategoryRepository
{
    Task AddAsync(Category category);
    void Update(Category category);
    void Delete(int id);
    Task<Category> GetByIdAsync(int id);
    IQueryable<Category> GetAll();
}
