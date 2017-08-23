using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Repositories
{
    public interface IRepository<T> where T: class
    {
        T Add(T entity);
        T Get(int id);
        IQueryable<T> GetAll();
        T Update(T entity);
        void Delete(T entity);
    }
}
