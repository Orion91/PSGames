using System;
using System.Collections.Generic;

namespace PSGames.API.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string AvatarUrl { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime LastActiveDate { get; set; }
        public ICollection<UserLibraryGame> UserGameLibraries { get; set; }
    }
}