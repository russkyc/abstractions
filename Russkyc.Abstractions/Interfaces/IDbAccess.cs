using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Russkyc.Abstractions.Interfaces
{
    public interface IDbAccess
    {
        bool Add<T>(T item) where T : class, new();
        bool AddMultiple<T>(ICollection<T> item) where T : class, new();
        T Get<T>(Expression<Func<T, bool>> filter) where T : class, new();
        ICollection<T> GetMultiple<T>(Expression<Func<T, bool>> filter) where T : class, new();
        ICollection<T> GetCollection<T>() where T : class, new();
        bool Update<T>(Expression<Func<T, bool>> filter, Expression<Func<T,T>> action) where T : class, new();
        bool Update<T>(Expression<Func<T, bool>> filter, T item) where T : class, new();
        bool Update<T>(T item) where T : class, new();
        bool Delete<T>(Expression<Func<T, bool>> filter) where T : class, new();
        bool Delete<T>(object id) where T : class, new();
    }
}