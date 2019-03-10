using System.Collections.Generic;
using System.Threading.Tasks;
using PSGames.API.Models;

namespace PSGames.API.Data
{
    public interface IGameRepository
    {
         Task<IEnumerable<Game>> GetAllGames();
         Task<IEnumerable<Game>> GetUserGames();
         Task<Game> GetGame(int id);
    }
}