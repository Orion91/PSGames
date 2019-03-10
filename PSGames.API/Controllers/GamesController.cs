using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PSGames.API.Data;
using PSGames.API.DTOs;

namespace PSGames.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class GamesController : ControllerBase
    {
        private readonly IGameRepository _repo;
        private readonly IMapper _mapper;
        public GamesController(IGameRepository repo, IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;

        }

        [HttpGet]
        public async Task<IActionResult> GetAllGames()
        {
            var gamesFromRepo = await _repo.GetAllGames();

            var gamesToReturn = _mapper.Map<IEnumerable<GameForListDto>>(gamesFromRepo);

            return Ok(gamesToReturn);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetGame(int id)
        {
            var gameFromRepo = await _repo.GetGame(id);

            var gameToReturn = _mapper.Map<GameForListDto>(gameFromRepo);

            return Ok(gameToReturn);
        }
    }
}