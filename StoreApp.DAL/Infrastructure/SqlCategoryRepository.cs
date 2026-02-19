using Microsoft.EntityFrameworkCore;
using StoreApp.DAL.Context;
using StoreApp.Domain.Entities;
using StoreApp.Repository.Repositories;
using System;

namespace StoreApp.DAL.Infrastructure;

public class SqlCategoryRepository : BaseSqlRepository, ICategoryRepository
{
    private readonly StoreAppDbContext _context;

    public SqlCategoryRepository(string connectionString, StoreAppDbContext context) : base(connectionString)
    {
        _context = context;
    }

    public async Task AddAsync(Category category)
    {
        await _context.AddAsync(category);
    }

    public void Delete(int id)
    {
        var category = _context.Categories.Find(id);
        category.IsDeleted = true;
        category.DeletedDate = DateTime.UtcNow;
    }

    public IQueryable<Category> GetAll()
    {
        return _context.Categories.Where(c => !c.IsDeleted);
    }

    public async Task<Category> GetByIdAsync(int id)
    {
        return await _context.Categories.FirstOrDefaultAsync(c => c.Id == id && !c.IsDeleted);
    }

    public void Update(Category category)
    {
        category.UpdatedDate = DateTime.UtcNow;
        _context.Categories.Update(category);
    }
}