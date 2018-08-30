using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Coworking.Api.DataAccess.Contracts.Repositories
{
    public interface IRepository<T> where T : class
    {
        Task<bool> Exist(int id);
        Task<IEnumerable<T>> GetAll();
        Task<T> Get(int id);
        Task DeleteAsync(int id);
        Task<T> Update(int id, T element);
        Task<T> Add(T element);
    }
}
