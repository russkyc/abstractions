using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Russkyc.Abstractions.Interfaces
{
    public interface IRepository<T> where T : class, new()
    {
        bool Add(T item);
        bool AddMultiple(ICollection<T> item);
        T Get(Expression<Func<T, bool>> filter);
        ICollection<T> GetMultiple(Expression<Func<T, bool>> filter);
        ICollection<T> GetCollection();
        bool Update(Expression<Func<T, bool>> filter, Expression<Func<T,T>> action);
        bool Delete(Expression<Func<T, bool>> filter);
    }
}