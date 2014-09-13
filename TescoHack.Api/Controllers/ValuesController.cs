using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using TescoHack.Api.Datas;
using TescoHack.Api.Models;
using ActionFilterAttribute = System.Web.Http.Filters.ActionFilterAttribute;

namespace TescoHack.Api.Controllers
{
    public class AcceptCorsAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            base.OnActionExecuted(actionExecutedContext);
            actionExecutedContext.Response.Headers.Add("Access-Control-Allow-Origin", "*");
        }
    }

    [AcceptCors]
    public class GameController : ApiController
    {
        // GET api/values
        public IEnumerable<Game> Get()
        {
            return new[] {Database.Game};
        }

        // GET api/values/5
        public Game Get(string id)
        {
            return Database.Game;
        }

        // POST api/values
        public Game Post([FromBody]Game value)
        {
            Database.Game = Game.Init();
            return Database.Game;
        }

        // PUT api/values/5
        public void Put(string id, [FromBody]Game value)
        {
            value.Id = id;
            Database.Game = value;
        }

        // DELETE api/values/5
        public void Delete(string id)
        {
            Database.Game = null;
        }
    }
}
