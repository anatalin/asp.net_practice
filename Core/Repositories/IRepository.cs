using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Repositories
{
    public interface IRepository<T> where T: class
    {
        T Add(T entity);
        T Get(int id);
        IEnumerable<T> GetAll();
        T Update(T entity);
        void Delete(T entity);
        void Delete(int entityId);
        IEnumerable<T> GetByExpression(Expression<Func<T, bool>> predicate);
    }
}
