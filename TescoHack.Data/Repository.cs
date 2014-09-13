using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using TescoHack.Domain;

namespace TescoHack.Data
{
    public class Repository<T> : IRepository<T>
        where T : DomainObject
    {
        protected readonly MongoDatabase _mongoDatabase;

        public Repository(MongoDatabase mongoDatabase)
        {
            _mongoDatabase = mongoDatabase;
        }

        public void Create(T item)
        {
            var collection = _mongoDatabase.GetCollection<T>(typeof(T).Name);
            item.Updated = item.Created = DateTime.Now;
            collection.Insert(item);
        }

        public IList<T> FindAll()
        {
            var collection = _mongoDatabase.GetCollection<T>(typeof(T).Name);
            return collection.FindAll().ToList();
        }

        public IList<T> FindBy<TArg>(Expression<Func<T, TArg>> expression, IEnumerable<TArg> args)
        {
            var collection = _mongoDatabase.GetCollection<T>(typeof(T).Name);
            var query = Query<T>.In(expression, args);
            return collection.FindAs<T>(query).ToList();
        }

        public T Get(Guid id)
        {
            var collection = _mongoDatabase.GetCollection<T>(typeof(T).Name);
            var query = Query<T>.EQ(e => e.Id, id);
            return collection.FindOne(query);
        }

        public void Update(T item)
        {
            var collection = _mongoDatabase.GetCollection<T>(typeof(T).Name);
            item.Updated = DateTime.Now;
            collection.Save(item);
        }

        public void Delete(Guid id)
        {
            var query = Query<T>.EQ(e => e.Id, id);
            var collection = _mongoDatabase.GetCollection<T>(typeof(T).Name);
            collection.Remove(query);
        }
    }
}
