

using AutoMapper;
using eCommerce.Core.DTOs;
using eCommerce.Core.Entities;

namespace eCommerce.Core.Mappers
{
    public class RegisterRequestMappingProfile : Profile
    {
        public RegisterRequestMappingProfile()
        {
            CreateMap<RegisterRequest, ApplicationUser>();

        }
    }
}
