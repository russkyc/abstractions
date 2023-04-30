// MIT License
// 
// Copyright (c) 2023 Russell Camo (Russkyc)
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
// SOFTWARE.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Russkyc.Abstractions.Interfaces
{
    public interface IDbAccessAsync
    {
        Task<bool> Add<T>(T item);
        Task<bool> AddMultiple<T>(ICollection<T> item);
        Task<T> Get<T>(Func<T, bool> filter);
        Task<ICollection<T>> GetMultiple<T>(Func<T, bool> filter);
        Task<ICollection<T>> GetCollection<T>();
        Task<bool> Update<T>(Func<T, bool> filter, Action<T> action);
        Task<bool> Update<T>(Func<T, bool> filter, T item);
        Task<bool> Delete<T>(Func<T, bool> filter);
    }
}