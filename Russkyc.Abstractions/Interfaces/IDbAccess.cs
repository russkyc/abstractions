using System;
using System.Collections.Generic;

namespace Russkyc.Abstractions.Interfaces
{
    public interface IDbAccess
    {
        bool Add<T>(T item) where T : new();
        bool AddMultiple<T>(ICollection<T> item) where T : new();
        T Get<T>(Func<T, bool> filter) where T : new();
        ICollection<T> GetMultiple<T>(Func<T, bool> filter) where T : new();
        ICollection<T> GetCollection<T>() where T : new();
        bool Update<T>(Func<T, bool> filter, Func<T,T> action) where T : new();
        bool Update<T>(Func<T, bool> filter, T item) where T : new();
        bool Update<T>(T item) where T : new();
        bool Delete<T>(Func<T, bool> filter) where T : new();
        bool Delete<T>(object id) where T : new();
    }
}