﻿using System.Collections.Generic;
using System.Web.Http;
using TescoHack.Api.Datas;
using TescoHack.Api.Models;

namespace TescoHack.Api.Controllers
{
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
        public void Post([FromBody]Game value)
        {
            Database.Game = Game.Init();
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
