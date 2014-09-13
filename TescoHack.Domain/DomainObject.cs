using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace TescoHack.Domain
{
    [BsonIgnoreExtraElements(true)]
    public class DomainObject
    {
        public Guid Id { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }

        [BsonExtraElements]
        public BsonDocument ExtraElements { get; set; }

        public DomainObject() { }

        protected DomainObject(DomainObject domainObject)
        {
            Id = domainObject.Id;
            Created = domainObject.Created;
            Updated = domainObject.Updated;
        }
    }
}