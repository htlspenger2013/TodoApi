using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace TodoApi.Models
{
    public interface IRepository<T> {
        void Insert(T entity);
        void Delete(T entity);
        void Update(T entity);
        IEnumerable<T> SearchFor(Expression<Func<T, bool>> predicate);
        IEnumerable<T> GetAll();
        T GetById(object id);
    }
}
