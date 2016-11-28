using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace TodoApi.Models
{
    public class TodoRepository : IRepository<TodoItem> {
        private static ConcurrentDictionary<string, TodoItem> _todos =
            new ConcurrentDictionary<string, TodoItem>();

        public TodoRepository() {
            Insert(new TodoItem { Name = "Item1" });
        }

        public void Insert(TodoItem entity) {
            entity.Key = Guid.NewGuid().ToString();
            _todos[entity.Key] = entity;
        }

        public void Delete(TodoItem entity) {
            TodoItem item;
            _todos.TryRemove(entity.Key, out item);
            //return item;  // 
        }

        public void Update(TodoItem item) {
            _todos[item.Key] = item;
        }

        public IEnumerable<TodoItem> SearchFor(Expression<Func<TodoItem, bool>> predicate) {
            var f = predicate.Compile();    // noch genauer anschauen
            return GetAll().Where(f);
        }

        public IEnumerable<TodoItem> GetAll() {
            return _todos.Values;
        }

        public TodoItem GetById(object id) {
            TodoItem item;
            _todos.TryGetValue(id as string, out item);
            return item;
        }
    }
}
