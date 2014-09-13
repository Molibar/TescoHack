using System;
using System.Collections.Generic;
using System.Web.Http;
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
            return _gameRepository.FindAll();
        }

        // GET: api/Game/5
        public Game Get(Guid id)
        {
            return _gameRepository.Get(id);
        }

        // POST: api/Game
        public Game Post([FromBody]Game game)
        {
            if (game == null)
            {
                game = Game.Init();
                _gameRepository.Create(game);
                return game;
            }
            _gameRepository.Update(game);
            return game;
        }

        // PUT: api/Game/5
        public Game Put(Guid id, [FromBody]Game game)
        {
            _gameRepository.Update(game);
            return game;
        }

        // DELETE: api/Game/5
        public void Delete(Guid id)
        {
            _gameRepository.Delete(id);
        }
    }
}
