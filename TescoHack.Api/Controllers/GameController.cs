using System.Collections.Generic;
using System.Web.Http;
using Molibar.Framework.Extensions;
using TescoHack.Domain;

namespace TescoHack.Api.Controllers
{
    public class GameController : ApiController
    {
        private readonly IRepository<Game> _gameRepository;

        public GameController(IRepository<Game> gameRepository)
        {
            _gameRepository = gameRepository;
        }

        // GET: api/Game
        public IEnumerable<Game> Get()
        {
            return _gameRepository.Get("Flash").ToSingleElementList();
        }

        // GET: api/Game/5
        public Game Get(string id)
        {
            return _gameRepository.Get("Flash");
        }

        // POST: api/Game
        public Game Post([FromBody]Game game)
        {
            if (game == null)
            {
                game = Game.Init();
            }
            _gameRepository.Create(game);
            return game;
        }

        // PUT: api/Game/5
        public Game Put(string id, [FromBody]Game game)
        {
            game.Id = id;
            return Post(game);
        }

        // DELETE: api/Game/5
        public void Delete(string id)
        {
            _gameRepository.Delete(id);
        }
    }
}
