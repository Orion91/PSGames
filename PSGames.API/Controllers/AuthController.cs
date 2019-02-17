using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using PSGames.API.Data;
using PSGames.API.DTOs;
using PSGames.API.Models;

namespace PSGames.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _repo;
        private readonly IConfiguration _config;

        public AuthController(IAuthRepository repo, IConfiguration config)
        {
            _repo = repo;
            _config = config;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserForRegisterDto userForRegisterDto)
        {
            if (await _repo.UserExistsAsync(userForRegisterDto.Username))
            {
                return BadRequest("Username already exists");
            }
            
            var userToCreate = new User
            {
                Username = userForRegisterDto.Username,
                CreatedDate = userForRegisterDto.CreatedDate,
                LastActiveDate = userForRegisterDto.LastActiveDate
            };

            var createdUser = await _repo.RegisterAsync(userToCreate, userForRegisterDto.Password);

            return Ok(createdUser);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserForLoginDto userForLogin)
        {
            var userFromRepo = await _repo.LoginAsync(userForLogin.Username, userForLogin.Password);

            if (userFromRepo == null)
            {
                return Unauthorized();
            }

            var claims = new []
            {
                new Claim(ClaimTypes.NameIdentifier, userFromRepo.Id.ToString()),
                new Claim(ClaimTypes.Name, userFromRepo.Username)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.GetSection("AppSettings:Token").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = creds
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            
            return Ok(new
            {
                token = tokenHandler.WriteToken(token)
            });
        }
    }
}
