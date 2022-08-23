using AutoMapper;
using Searching_Tool_Assignment.DTOs;
using Searching_Tool_Assignment.Models;

namespace Searching_Tool_Assignment.Mappings
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<RegisterDTO, ApplicationUser>();
        }
    }
}
