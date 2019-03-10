using System.Collections.Generic;
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

        public Task<IEnumerable<Game>> GetUserGames()
        {
            throw new System.NotImplementedException();
        }
    }
}