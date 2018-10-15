using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using Core.Exceptions;

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
                var toDeleteAuthor = context.Authors.FirstOrDefault(a => a.AuthorId == entity.AuthorId);

                if (toDeleteAuthor == null)
                    throw new NotFoundException($"Автор с id = {entity.AuthorId} не найден.");

                context.Authors.Remove(toDeleteAuthor);
                context.SaveChanges();
            }
        }

        public void Delete(int entityId)
        {
            using (LearnDBContext context = new LearnDBContext())
            {
                var toDeleteAuthor = context.Authors.FirstOrDefault(a => a.AuthorId == entityId);

                if (toDeleteAuthor == null)
                    throw new NotFoundException($"Автор с id = {entityId} не найден.");

                context.Authors.Remove(toDeleteAuthor);
                context.SaveChanges();
            }
        }

        public Author Get(int id)
        {
            using (LearnDBContext context = new LearnDBContext())
            {
                context.UseRecompileOption = true;

                var result = context.Authors.Where(a => a.AuthorId == id).SingleOrDefault();

                if (result == null)
                    throw new NotFoundException($"Автор с id = {id} не найден.");

                return result;                
            }
        }

        public IEnumerable<Author> GetAll()
        {
            using (LearnDBContext context = new LearnDBContext())
            {
                context.UseRecompileOption = true;
                var authorList = context.Authors.ToList();

                if (authorList.Count() == 0)
                    throw new NotFoundException("Не был найден ни один автор.");

                return authorList;
            }
        }

        public IEnumerable<Author> GetByExpression(Expression<Func<Author, bool>> predicate)
        {
            using(LearnDBContext context = new LearnDBContext())
            {
                context.UseRecompileOption = true;
                var authorList = context.Authors.Where(predicate).ToList();

                if (authorList.Count() == 0)
                    throw new NotFoundException("Не был найден ни один автор по заданному критерию.");

                return authorList;
            }
        }

        public Author Update(Author entity)
        {
            using (LearnDBContext context = new LearnDBContext())
            {
                var updatedAuthor = context.Authors.SingleOrDefault(p => p.AuthorId == entity.AuthorId);

                if (updatedAuthor == null)
                    throw new NotFoundException($"Автор с id = {entity.AuthorId} не найден.");

                context.Entry(updatedAuthor).CurrentValues.SetValues(entity);
                context.SaveChanges();

                return updatedAuthor;
            }
        }
    }
}
