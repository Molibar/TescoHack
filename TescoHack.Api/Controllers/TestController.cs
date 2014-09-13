using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Management;
using MongoDB.Bson;
using TescoHack.Domain;

namespace TescoHack.Api.Controllers
{
    public class TestController : ApiController
    {
        private readonly IRepository<Thingy> _thingyRepository;

        public TestController(IRepository<Thingy> thingyRepository)
        {
            //new LogEvent("TestController Constructor " + thingyRepository).Raise();
            _thingyRepository = thingyRepository;
        }

        // GET: api/Test
        public IEnumerable<Thingy> Get()
        {
            _thingyRepository.Create(new Thingy
            {
                Id = "Thingy:Love",
                Name = "Test1"
            });
            _thingyRepository.Create(new Thingy
            {
                Id = "Thingy:Hate",
                Name = "Test2"
            });

            // insert object
            var thingies = new List<Thingy>
            {
                _thingyRepository.Get("Thingy:Love"),
                _thingyRepository.Get("Thingy:Hate")
            };
            foreach (var thingy in thingies)
            {
                _thingyRepository.Delete(thingy.Id);
            }
            return thingies;
        }
    }

    public class LogEvent : WebRequestErrorEvent
    {
        public LogEvent(string message)
            : base(null, null, 100001, new Exception(message))
        {
        }
    }

    public class Thingy : DomainObject
    {
        public string Name { get; set; }
    }
}