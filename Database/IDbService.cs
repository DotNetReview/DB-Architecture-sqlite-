using SQLite;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public interface IDbService<T>
        where T : new()
    {
        SQLiteAsyncConnection Connection { get; }

        Task Add(T data);
        Task AddRange(IEnumerable<T> data);

        Task<List<T>> GetAll();
        Task<List<T>> Where(Expression<Func<T, bool>> predicateExpression);
        Task<T> FirstOrDefault(Expression<Func<T, bool>> predicateExpression);
        Task<T> FirstOrDefault();
        Task<T> GetById(object id);

        Task<bool> Exists(object id);

        Task Delete(T data);
        Task DeleteAll();
        Task DeleteAll(IEnumerable<T> data);

        Task Update(T data);
        Task UpdateAll(IEnumerable<T> data);

        Task AddOrUpdate(T data);
        Task AddOrUpdateAll(IEnumerable<T> rangeData);

        Task DropTable();
    }
}
