namespace TescoHack.Domain
{
    public interface IRepository<T>
        where T : DomainObject
    {
        void Create(T item);
        T Get(string id);
        void Delete(string id);
    }
}