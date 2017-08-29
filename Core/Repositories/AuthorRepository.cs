using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace Core.Repositories
{
    public class AuthorRepository : IRepository<Author>
    {
        public Author Add(Author entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Author entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int entityId)
        {
            throw new NotImplementedException();
        }

        public Author Get(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Author> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Author> GetByExpression(Expression<Func<Author, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Author Update(Author entity)
        {
            throw new NotImplementedException();
        }

        IEnumerable<Author> IRepository<Author>.GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
