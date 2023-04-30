using System;
using System.Collections.Generic;

namespace Russkyc.Abstractions.Interfaces
{
    public interface IDbAccess
    {
        bool Add<T>(T item);
        bool AddMultiple<T>(ICollection<T> item);
        T Get<T>(Func<T, bool> filter);
        ICollection<T> GetMultiple<T>(Func<T, bool> filter);
        ICollection<T> GetCollection<T>();
        bool Update<T>(Func<T, bool> filter, Action<T> action);
        bool Update<T>(Func<T, bool> filter, T item);
        bool Delete<T>(Func<T, bool> filter);
    }
}