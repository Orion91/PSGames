using System.Collections.Generic;

namespace PSGames.API.Models
{
    public class Game
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public Platform Platform { get; set; }
        public ICollection<UserGameLibrary> UserGameLibraries { get; set; }
    }
}