

using AutoMapper;
using UserService.Core.DTOs;
using UserService.Core.Entities;

namespace UserService.Core.Mappers
{
    public class RegisterRequestMappingProfile : Profile
    {
        public RegisterRequestMappingProfile()
        {
            CreateMap<RegisterRequest, ApplicationUser>();

        }
    }
}
