using AutoMapper;
using ECommerceApp.Core.DTOs.Auth;
using ECommerceApp.Core.DTOs.Product;
using ECommerceApp.Core.Entities;

namespace ECommerceApp.Core.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // User
            CreateMap<RegisterDto, User>()
                .ForMember(dest => dest.PasswordHash, opt => opt.Ignore());

            // Product
            CreateMap<Product, ProductDto>()
                .ForMember(dest => dest.Categories,
                    opt => opt.MapFrom(src =>
                        src.ProductCategories.Select(pc => pc.Category.Name).ToList()));

            CreateMap<CreateProductDto, Product>();
        }
    }
}