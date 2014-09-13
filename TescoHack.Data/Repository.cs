using System;
using ServiceStack.Redis;
using TescoHack.Domain;

namespace TescoHack.Data
{
    public class Repository<T> : IRepository<T>
        where T : DomainObject
    {
        protected readonly RedisClient RedisClient;

        public Repository(RedisClient redisClient)
        {
            RedisClient = redisClient;
        }

        public void Create(T item)
        {
            item.Updated = item.Created = DateTime.Now;
            RedisClient.Set(item.Id, item);
        }

        public T Get(string id)
        {
            return RedisClient.Get<T>(id);
        }

        public void Delete(string id)
        {
            RedisClient.Remove(id);
        }
    }
}
