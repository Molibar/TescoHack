using System.Web.Http;
using TescoHack.Api.Datas;
using TescoHack.Api.Models;

namespace TescoHack.Api.Controllers
{
    [AcceptCors]
    public class ActionController : ApiController
    {

        [HttpGet]
        [Route("api/CheckIn/{characterName}")]
        public Game CheckIn(string characterName)
        {
            if (Database.Game == null) Database.Game = Game.Init();
            Database.Game.CheckIn(characterName);
            return Database.Game;
        }

        [HttpGet]
        [Route("api/Scan/{missionId}/{characterName}")]
        public Game Scan(int missionId, string characterName)
        {
            if (Database.Game == null) Database.Game = Game.Init();
            Database.Game.FinishMission(characterName, missionId);
            return Database.Game;
        }

        [HttpGet]
        [Route("api/CheckOut/{characterName}")]
        public Game CheckOut(string characterName)
        {
            if (Database.Game == null) Database.Game = Game.Init();
            Database.Game.CheckOut(characterName);
            return Database.Game;
        }
    }
}