

using AutoMapper;
using eCommerce.Core.DTOs;
using eCommerce.Core.Entities;

namespace eCommerce.Core.Mappers
{
    public class ApplicationUserMappingProfile : Profile
    {
        public ApplicationUserMappingProfile()
        {

            CreateMap<ApplicationUser, AuthenticationResponse>();



        }
    }
}
