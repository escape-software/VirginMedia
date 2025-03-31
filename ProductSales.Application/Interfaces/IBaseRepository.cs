//-------------------------------------------------------------------------------------------------
// Name        : IBaseRepository
// Type        : Interface
// Author      : Kevin McGregor
// History     : 31-Mar-25 - Created
// Description :
// Copyright   : This is the property of Escape Software Solutions Limited and cannot be used, 
//               copied or modified without the express permission of the company in 
//               in writing. Copyright 2025 Escape Software Solutions Limited.
//-------------------------------------------------------------------------------------------------
using System.Linq.Expressions;

namespace ProductSales.Application.Interfaces;

public interface IBaseRepository<T> : IDisposable where T : class
{
    Task<T?> GetAsync(int id);

    Task<T?> GetAsync(Expression<Func<T, bool>> expression);

    Task<IEnumerable<T>> GetAllAsync();

    Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> whereCondition);

    Task<bool> InsertAsync(T entity);

    Task<bool> UpdateAsync(T entity, int key);

    Task<bool> DeleteAsync(T entity);

    Task<bool> DeleteAsync(int id);

    IQueryable<T> AsQueryable();
}
