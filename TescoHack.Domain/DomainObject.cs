using System;

namespace TescoHack.Domain
{
    public class DomainObject
    {
        public string Id { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }

        public DomainObject() { }

        protected DomainObject(DomainObject domainObject)
        {
            Id = domainObject.Id;
            Created = domainObject.Created;
            Updated = domainObject.Updated;
        }
    }
}