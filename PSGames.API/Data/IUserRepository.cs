using System.Collections.Generic;
using System.Threading.Tasks;
using PSGames.API.Models;

namespace PSGames.API.Data
{
    public interface IUserRepository
    {
         Task<IEnumerable<User>> GetUsers();
         Task<User> GetUser(int id);
    }
}