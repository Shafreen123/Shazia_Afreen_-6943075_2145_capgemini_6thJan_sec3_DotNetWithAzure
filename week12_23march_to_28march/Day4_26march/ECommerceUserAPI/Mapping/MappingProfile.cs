using AutoMapper;
using ECommerceUserAPI.Models;
using ECommerceUserAPI.DTOs;

namespace ECommerceUserAPI.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        // User entity → UserDTO (for GET response, hides Password)
        CreateMap<User, UserDTO>();

        // RegisterDTO → User entity (for saving to DB)
        CreateMap<RegisterDTO, User>();
    }
}