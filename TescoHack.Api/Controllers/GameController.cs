using System.Collections.Generic;
using System.Web.Http;
using TescoHack.Domain;

namespace TescoHack.Api.Controllers
{
    public class GameController : ApiController
    {
        public GameController(IRepository<Game> questRepository)
        {
            
        }

        // GET: api/Game
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Game/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Game
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Game/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Game/5
        public void Delete(int id)
        {
        }
    }
}
