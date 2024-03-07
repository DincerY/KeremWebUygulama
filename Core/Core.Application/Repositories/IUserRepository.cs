using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Core.Application.Repositories;

public interface IUserRepository
{
    DbSet<User> Table { get; }
    IQueryable<User> GetAll(bool changeTracking = true);
    IQueryable<User> GetWhere(Expression<Func<User, bool>> method);
    Task<User> GetSingleAsync(Expression<Func<User, bool>> method);
    Task<User> GetByIdAsync(int id);
    Task<bool> AddAsync(User model);
    bool Remove(User model);
    bool Update(User model);
    Task<int> SaveAsync();
}