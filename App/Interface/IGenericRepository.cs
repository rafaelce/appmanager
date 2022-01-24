using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace App.Interface
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> Get(Guid? id);
        Task<IReadOnlyList<T>> GetAll();
        Task<T> Add(T entity);
        Task<bool> Exists(Guid? id);
        Task Update(T entity);
        Task Delete(T entity);
    }
}
