using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using PSGames.API.Models;

namespace PSGames.API.Data.Seeds
{
    public class Seed
    {
        private readonly DataContext _context;
        public Seed(DataContext context)
        {
            _context = context;
        }

        public void SeedGames()
        {
            var ps3GameData = System.IO.File.ReadAllText("Data/Seeds/PS3GamesSeedData.json");
            var psVitaGameData = System.IO.File.ReadAllText("Data/Seeds/PSVitaGamesSeedData.json");
            var ps4GameData = System.IO.File.ReadAllText("Data/Seeds/PS4GamesSeedData.json");

            var ps3Games = JsonConvert.DeserializeObject<List<Game>>(ps3GameData);
            var psVitaGames = JsonConvert.DeserializeObject<List<Game>>(psVitaGameData);
            var ps4Games = JsonConvert.DeserializeObject<List<Game>>(ps4GameData);

            var allGames = ps3Games.Concat(psVitaGames)
                                    .Concat(ps4Games)
                                    .ToList();

            foreach (var game in allGames)
            {
                _context.Games.Add(game);
            }

            _context.SaveChanges();
        }
    }
}