using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Russkyc.Abstractions.Interfaces
{
    public interface IDbAccess
    {
        bool Insert<T>(T item);
        bool Insert<T>(ICollection<T> item);
        T Get<T>(Expression<Func<T, bool>> filter);
        T Get<T>(Func<T, bool> filter);
        ICollection<T> GetAll<T>(Expression<Func<T, bool>> filter);
        ICollection<T> GetAll<T>(Func<T, bool> filter);
        ICollection<T> GetCollection<T>();
        bool Update<T>(Expression<Func<T, bool>> filter, Action<T> action);
        bool Update<T>(Func<T, bool> filter, Action<T> action);
        bool Update<T>(Expression<Func<T, bool>> filter, T item);
        bool Update<T>(Func<T, bool> filter, T item);
        bool Delete<T>(Expression<Func<T, bool>> filter);
        bool Delete<T>(Func<T, bool> filter);
    }
}