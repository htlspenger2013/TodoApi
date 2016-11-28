using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace TodoApi.Models
{
    public class GenericRepository<TEntity> : IRepository<TEntity> where TEntity : class {
        internal DbContext context;
        internal DbSet<TEntity> dbSet;

        public GenericRepository(DbContext context) {
            this.context = context;
            this.dbSet = context.Set<TEntity>();
        }

        /////////////////////////////////////////////////////////////////////

        public IEnumerable<TEntity> GetAll() {
            return context.Set<TEntity>();
        }
        // public virtual TEntity Find([NotNull] params object[] keyValues)

        public TEntity GetById(object id) {
            return context.Set<TEntity>().Find(id);
        }
        public virtual void Insert(TEntity entity) {
            dbSet.Add(entity);
        }
        public virtual void Delete(object id) {
            TEntity entityToDelete = dbSet.Find(id);
            Delete(entityToDelete);
        }

        public IEnumerable<TEntity> SearchFor(Expression<Func<TEntity, bool>> predicate) {
            throw new NotImplementedException();
        }






    }
}
