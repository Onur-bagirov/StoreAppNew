using Microsoft.EntityFrameworkCore;
using StoreApp.DAL.Context;
using StoreApp.Domain.Entities;
using StoreApp.Repository.Repositories;
namespace StoreApp.DAL.Infrastructure
{
    public class SqlProductRepository : BaseSqlRepository,IProductRepository
    {
        private readonly StoreAppDbContext _context;

        public SqlProductRepository(string connectionString, StoreAppDbContext context) : base(connectionString)
        {
            _context = context;
        }

        public async Task AddAsync(Product product)
        {
            await _context.AddAsync(product);
        }

        public void Delete(int id)
        {
            var product = _context.Products.Find(id);
            product.IsDeleted = true;
            product.DeletedDate = DateTime.UtcNow;
        }

        public IQueryable<Product> GetAll()
        {
            return _context.Products.Where(c => !c.IsDeleted);
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            return await _context.Products.FirstOrDefaultAsync(c => c.Id == id && !c.IsDeleted);
        }

        public void Update(Product product)
        {
            product.UpdatedDate = DateTime.UtcNow;
            _context.Products.Update(product);
        }
    }
}