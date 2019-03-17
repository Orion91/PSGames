using System.Collections.Generic;
using System.Threading.Tasks;
using PSGames.API.Models;

namespace PSGames.API.Data
{
    public interface IGameRepository
    {
         Task<IEnumerable<Game>> GetAllGames();
         Task<IEnumerable<Game>> GetUserGames(int userId);
         Task<Game> GetGame(int id);
         Task<UserLibraryGame> GetUserGame(int userId, int gameId);
    }
}