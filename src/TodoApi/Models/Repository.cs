using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace TodoApi.Models
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class {
        protected DbContext db;
        private DbSet<TEntity> table;

        public Repository(DbContext dbContext) {
            this.db = dbContext;
            this.table = dbContext.Set<TEntity>();
        }

        public IEnumerable<TEntity> GetAll() {
            return db.Set<TEntity>();
        }

        public TEntity GetById(object id) {
            return db.Set<TEntity>().Find(id);
        }
        public virtual void Insert(TEntity entity) {
            table.Add(entity);
        }

        public IEnumerable<TEntity> SearchFor(Expression<Func<TEntity, bool>> predicate) {
            return table.Where<TEntity>(predicate);
        }

        public void Delete(TEntity entity) {
            Delete(entity);
        }

        public void Update(TEntity entity) {
            table.Attach(entity);
            db.Entry<TEntity>(entity).State = EntityState.Modified;
        }

        /////////////////////////////////////////////////////////////////////
        public virtual void Delete(object id) {
            TEntity entity = GetById(id);
            if (entity == null) return;
            Delete(entity);
        }

    }
}
