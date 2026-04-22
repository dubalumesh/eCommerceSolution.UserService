

using AutoMapper;
using UserService.Core.DTOs;
using UserService.Core.Entities;

namespace UserService.Core.Mappers
{
    public class ApplicationUserMappingProfile : Profile
    {
        public ApplicationUserMappingProfile()
        {

            CreateMap<ApplicationUser, AuthenticationResponse>();



        }
    }
}
