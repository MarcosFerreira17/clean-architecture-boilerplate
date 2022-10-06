using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Interfaces
{
    public interface IEmployeeRepository<T> where T : class
    {
        Task Add(T entity);
        Task Remove(long id);
        Task Update(T entity);
        Task<T> GetById(long id);
        IEnumerable<T> GetAll();
    }
}
