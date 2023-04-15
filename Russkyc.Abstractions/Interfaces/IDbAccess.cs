using System;
using System.Collections.Generic;

namespace Russkyc.Abstractions.Interfaces
{
    public interface IDbAccess
    {
        bool Insert<T>(T item);
        bool Insert<T>(ICollection<T> item);
        T Get<T>(Func<T, bool> filter);
        ICollection<T> GetAll<T>(Func<T, bool> filter);
        ICollection<T> GetCollection<T>();
        bool Update<T>(Func<T, bool> filter, Action<T> action);
        bool Delete<T>(Func<T, bool> filter);
    }
}