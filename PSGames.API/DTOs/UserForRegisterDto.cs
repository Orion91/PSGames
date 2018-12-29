using System;
using System.ComponentModel.DataAnnotations;

namespace PSGames.API.DTOs
{
    public class UserForRegisterDto
    {
        [Required]
        public string Username { get; set; }
        
        [Required]
        [StringLength(16, MinimumLength = 8, ErrorMessage = "You must specify password between 8 and 16 characters")]
        public string Password { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime LastActiveDate { get; set; }

        public UserForRegisterDto()
        {
            CreatedDate = DateTime.Now;
            LastActiveDate = DateTime.Now;
        }
    }
}