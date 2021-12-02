using Domain.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface IBaseRepository<T> where T:class
    {
        void Delete(int id);

        void Update(T entity);
        Task<bool> Insert(T entity);
        Task<T> GetTById(int id);
        IEnumerable<T> GetTs();
        Task<int> Save();
        int ReturnCount();
    }
}
