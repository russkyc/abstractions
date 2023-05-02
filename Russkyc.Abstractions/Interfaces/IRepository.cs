using System;
using System.Collections.Generic;

namespace Russkyc.Abstractions.Interfaces
{
    public interface IRepository<T> where T : new()
    {
        bool Add(T item);
        bool AddMultiple(ICollection<T> item);
        T Get(Func<T, bool> filter);
        ICollection<T> GetMultiple(Func<T, bool> filter);
        ICollection<T> GetCollection();
        bool Update(Func<T, bool> filter, Action<T> action);
        bool Delete(Func<T, bool> filter);
    }
}