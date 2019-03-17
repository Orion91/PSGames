using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PSGames.API.Models;

namespace PSGames.API.Data
{
    public class GameRepository : IGameRepository
    {
        private readonly DataContext _context;
        public GameRepository(DataContext context)
        {
            _context = context;

        }
        public async Task<IEnumerable<Game>> GetAllGames()
        {
            var games = await _context.Games.Include(p => p.Platform).ToListAsync();

            return games;
        }

        public async Task<Game> GetGame(int id)
        {
            var game = await _context.Games.Include(p => p.Platform).FirstOrDefaultAsync(g => g.Id == id);
            
            return game;
        }

        public async Task<UserLibraryGame> GetUserGame(int userId, int gameId)
        {
            var userLibraryGame = await _context.UsersGameLibraries
                .Include(g => g.Game)
                .Include(u => u.User)
                .FirstOrDefaultAsync(ugl => ugl.UserId == userId && ugl.GameId == gameId);

            return userLibraryGame;
        }

        public async Task<IEnumerable<Game>> GetUserGames(int userId)
        {
            var userLibraryGames = _context.UsersGameLibraries
                .Where(ulg => ulg.UserId == userId).Select(i => i.GameId);

            var userGames = await _context.Games
                .Include(p => p.Platform)
                .Where(g => userLibraryGames.Contains(g.Id))
                .ToListAsync();

            return userGames;
        }
    }
}