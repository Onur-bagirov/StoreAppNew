using StoreApp.DAL.Context;
using StoreApp.DAL.Infrastructure;
using StoreApp.Repository.Comman;
using StoreApp.Repository.Repositories;
using System;
using System.Net.Http.Headers;

namespace StoreApp.DAL.UnitOfWork;

public class SqlUnitOfWork : IUnitOfWork
{
    private readonly string _connectionString;
    private readonly StoreAppDbContext _context;

    public SqlUnitOfWork(string connectionString, StoreAppDbContext context)
    {
        _connectionString = connectionString;
        _context = context;
    }
    public SqlCategoryRepository _categoryRepository;
    public SqlProductRepository _productRepository;

    public ICategoryRepository CategoryRepository => _categoryRepository ??= new SqlCategoryRepository(_connectionString, _context);
    public IProductRepository ProductRepository => _productRepository ??= new SqlProductRepository(_connectionString, _context);

    public Task SaveChangesAsync()
    {
        return _context.SaveChangesAsync();
    }
}