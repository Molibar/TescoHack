using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using MongoDB.Bson;
using TescoHack.Domain;

namespace TescoHack.Api.Controllers
{
    public class TestController : ApiController
    {
        private readonly IRepository<Thingy> _thingyRepository;

        public TestController(IRepository<Thingy> thingyRepository)
        {
            _thingyRepository = thingyRepository;
        }

        // GET: api/Test
        public IEnumerable<Thingy> Get()
        {
            _thingyRepository.Create(new Thingy
            {
                Id = Guid.NewGuid(),
                Name = "Test1"
            });
            _thingyRepository.Create(new Thingy
            {
                Id = Guid.NewGuid(),
                Name = "Test2"
            });

            // insert object
            var thingies = _thingyRepository.FindAll();
            foreach (var thingy in thingies)
            {
                _thingyRepository.Delete(thingy.Id);
            }
            return thingies;
        }
    }

    public class Thingy : DomainObject
    {
        public string Name { get; set; }
    }
}