using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace TescoHack.Domain
{
    public interface IRepository<T>
        where T : DomainObject
    {
        T Get(Guid objectId);
        IList<T> FindAll();
        IList<T> FindBy<TArg>(Expression<Func<T, TArg>> expression, IEnumerable<TArg> args);
        void Create(T item);
        void Update(T item);
        void Delete(Guid id);
    }
}