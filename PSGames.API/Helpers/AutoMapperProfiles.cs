using AutoMapper;
using PSGames.API.DTOs;
using PSGames.API.Models;

namespace PSGames.API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<User, UserForListDto>(); 
        }
    }
} 