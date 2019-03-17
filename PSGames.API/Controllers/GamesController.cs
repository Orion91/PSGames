using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PSGames.API.Data;
using PSGames.API.DTOs;
using PSGames.API.Models;

namespace PSGames.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class GamesController : ControllerBase
    {
        private readonly IGameRepository _gameRepo;
        private readonly IMapper _mapper;
        private readonly IGenericRepository _genericRepo;
        public GamesController(IGenericRepository genericRepo, IGameRepository gameRepo, IMapper mapper)
        {
            _mapper = mapper;
            _gameRepo = gameRepo;
            _genericRepo = genericRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllGames()
        {
            var gamesFromRepo = await _gameRepo.GetAllGames();

            var gamesToReturn = _mapper.Map<IEnumerable<GameForListDto>>(gamesFromRepo);

            return Ok(gamesToReturn);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetGame(int id)
        {
            var gameFromRepo = await _gameRepo.GetGame(id);

            var gameToReturn = _mapper.Map<GameForListDto>(gameFromRepo);

            return Ok(gameToReturn);
        }

        [HttpPost("library/{userId}/add/{id}")]
        public async Task<IActionResult> AddGameToUserLibrary(int userId, int id)
        {
            var userLibraryGame = await _gameRepo.GetUserGame(userId, id);
            
            if (userLibraryGame != null)
            {
                return BadRequest("You already own this game");
            }

            if (await _gameRepo.GetGame(id) == null)
            {
                return NotFound();
            }

            userLibraryGame = new UserLibraryGame
            {
                UserId = userId,
                GameId = id
            };

            _genericRepo.Add<UserLibraryGame>(userLibraryGame);

            if (await _genericRepo.SaveAll())
            {
                return Ok();
            }

            return BadRequest("Failed to add game to your library");
        }

        [HttpGet("library/{userId}")]
        public async Task<IActionResult> GetUserLibrary(int userId)
        {
            var userGames = await _gameRepo.GetUserGames(userId);

            var userGamesToReturn = _mapper.Map<IEnumerable<GameForListDto>>(userGames);

            return Ok(userGamesToReturn);
        }

    }
}