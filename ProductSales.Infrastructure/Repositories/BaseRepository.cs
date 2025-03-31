//-------------------------------------------------------------------------------------------------
// Name        : BaseRepository
// Type        : Class
// Author      : Kevin McGregor
// History     : 31-Mar-25 - Created
// Description :
// Copyright   : This is the property of Escape Software Solutions Limited and cannot be used, 
//               copied or modified without the express permission of the company in 
//               in writing. Copyright 2025 Escape Software Solutions Limited.
//-------------------------------------------------------------------------------------------------
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using ProductSales.Application.Interfaces;
using ProductSales.Infrastructure.Context;
using System.Linq.Expressions;

namespace ProductSales.Infrastructure.Repositories;

public abstract class BaseRepository<T> : IBaseRepository<T> where T : class
{
    protected readonly ProductSalesDbContext context;

    public BaseRepository(IDbContextFactory<ProductSalesDbContext> factory)
    {
        context = factory.CreateDbContext();
    }

    public virtual async Task<T?> GetAsync(int id)
    {
        return await context.Set<T>().FindAsync(id);
    }

    public virtual async Task<T?> GetAsync(Expression<Func<T, bool>> expression)
    {
        return await context.Set<T>().Where(expression).SingleOrDefaultAsync();
    }

    public virtual async Task<IEnumerable<T>> GetAllAsync()
    {
        return await context.Set<T>().ToListAsync();
    }

    public virtual async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> expression)
    {
        return await context.Set<T>().Where(expression).ToListAsync();
    }

    public virtual async Task<bool> InsertAsync(T entity)
    {
        int result = 0;

        if (entity != null)
        {
            context.Set<T>().Add(entity);
            result = await context.SaveChangesAsync();
        }

        return result > 0 ? true : false;
    }

    public virtual async Task<bool> UpdateAsync(T entity, int key)
    {
        int result = 0;

        if (entity != null)
        {
            var existing = await context.FindAsync<T>(key);
            if (existing != null)
            {
                context.Entry(existing).CurrentValues.SetValues(entity);
                result = await context.SaveChangesAsync();
            }
        }

        return result > 0 ? true : false;
    }

    public virtual async Task<bool> DeleteAsync(T entity)
    {
        int result = 0;

        if (entity != null)
        {
            context.Set<T>().Remove(entity);
            result = await context.SaveChangesAsync();
        }

        return result > 0 ? true : false;
    }

    public virtual async Task<bool> DeleteAsync(int id)
    {
        int result = 0;

        if (id > 0)
        {
            var entity = await context.Set<T>().FindAsync(id);
            if (entity != null)
            {
                context.Set<T>().Remove(entity);
                result = await context.SaveChangesAsync();
            }
        }

        return result > 0 ? true : false;
    }

    public virtual IQueryable<T> AsQueryable()
    {
        return context.Set<T>().AsQueryable();
    }

    /// <summary>
    /// Dispose the dbContext.
    /// </summary>
    public void Dispose()
    {
        if (context != null)
        {
            context.Dispose();
        }
    }
}
