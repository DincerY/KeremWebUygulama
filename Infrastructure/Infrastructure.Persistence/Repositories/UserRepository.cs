using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Core.Application.Repositories;
using Core.Domain.Entities;
using Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Infrastructure.Persistence.Repositories;

public class UserRepository : IUserRepository
{
    private readonly WebAppDbContext _context;

    public UserRepository(WebAppDbContext context)
    {
        _context = context;
    }

    public DbSet<User> Table => _context.Set<User>();
    public IQueryable<User> GetAll(bool changeTracking = true)
    {
        var query = Table.AsQueryable();
        if (!changeTracking)
        {
            query.AsNoTracking();
        }
        return query;
    }

    public IQueryable<User> GetWhere(Expression<Func<User, bool>> method)
    {
        var query = Table.AsQueryable();
        return query.Where(method);
    }

    public async Task<User> GetSingleAsync(Expression<Func<User, bool>> method)
    {
        return await Table.SingleOrDefaultAsync();
    }

    public async Task<User> GetByIdAsync(int id)
    {
        return await Table.FindAsync(id);
    }

    public async Task<bool> AddAsync(User model)
    {
        _context.Entry(model).State = EntityState.Added;
        var result = await _context.SaveChangesAsync();
        return result == 1 ? true : false;
    }

    public bool Remove(User model)
    {
        _context.Entry(model).State = EntityState.Deleted;
        var result = _context.SaveChanges();
        return result == 1 ? true : false;
    }

    public bool Update(User model)
    {
        _context.Entry(model).State = EntityState.Modified;
        var result = _context.SaveChanges();
        return result == 1 ? true : false;
    }

    public async Task<int> SaveAsync()
    {
        return await _context.SaveChangesAsync();
    }
}