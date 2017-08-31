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
            using (LearnDBContext context = new LearnDBContext())
            {
                var author = context.Authors.Add(entity);
                context.SaveChanges();
                return author;
            }
        }

        public void Delete(Author entity)
        {
            using (LearnDBContext context = new LearnDBContext())
            {
                //Все связанные записи удаляются каскадно
                context.Authors.Remove(entity);
                context.SaveChanges();
            }
        }

        public void Delete(int entityId)
        {
            using (LearnDBContext context = new LearnDBContext())
            {
                Author toDelete = new Author { AuthorId = entityId };
                context.Authors.Attach(toDelete);
                context.Authors.Remove(toDelete);

                context.SaveChanges();
            }
        }

        public Author Get(int id)
        {
            using (LearnDBContext context = new LearnDBContext())
            {
                return context.Authors.Where(a=> a.AuthorId == id).SingleOrDefault();
            }
        }

        public IEnumerable<Author> GetAll()
        {
            using (LearnDBContext context = new LearnDBContext())
            {
                return context.Authors.ToList();
            }
        }

        public IEnumerable<Author> GetByExpression(Expression<Func<Author, bool>> predicate)
        {
            using(LearnDBContext context = new LearnDBContext())
            {
                return context.Authors.Where(predicate).ToList();
            }
        }

        public Author Update(Author entity)
        {
            using (LearnDBContext context = new LearnDBContext())
            {
                var updatedAuthor = context.Authors.SingleOrDefault(p => p.AuthorId == entity.AuthorId);

                if (updatedAuthor == null)
                {
                    return null;     
                }

                context.Entry(updatedAuthor).CurrentValues.SetValues(entity);
                context.SaveChanges();

                return updatedAuthor;
            }
        }
    }
}
