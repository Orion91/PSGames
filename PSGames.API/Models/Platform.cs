using System.Collections.Generic;

namespace PSGames.API.Models
{
    public class Platform
    {
        public int Id { get; set; }
        public string ShortName { get; set; }
        public string FullName { get; set; }
        public string IconUrl { get; set; }
        public ICollection<Game> Games { get; set; }
    }
}