using System;
using System.Collections.Generic;

namespace Russkyc.Abstractions.Interfaces
{
    public interface IRepository<T>
    {
        bool Insert(T item);
        bool Insert(ICollection<T> item);
        T Get(Func<T, bool> filter);
        ICollection<T> GetAll(Func<T, bool> filter);
        ICollection<T> GetCollection();
        bool Update(Func<T, bool> filter, Action<T> action);
        bool Delete(Func<T, bool> filter);
        IRepository<T> GetInstance();
    }
}