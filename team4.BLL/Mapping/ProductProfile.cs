using team4.BLL.Dtos.Product;
using team4.DAL.Entities;
using AutoMapper;

namespace team4.BLL.Mapping
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            // Entity ↔ ProductDto
            CreateMap<ProductEntity, ProductDto>()
                .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.CategoryId))
                .ReverseMap()
                .ForMember(dest => dest.CategoryId, opt => opt.MapFrom(src => src.Category))
                .ForMember(dest => dest.Category, opt => opt.Ignore());

            // CreateProductDto → ProductEntity
            CreateMap<CreateProductDto, ProductEntity>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.CategoryId, opt => opt.MapFrom(src => src.Category))
                .ForMember(dest => dest.Category, opt => opt.Ignore())
                .ForMember(dest => dest.Image, opt => opt.Ignore());

            // UpdateProductDto → ProductEntity
            CreateMap<UpdateProductDto, ProductEntity>()
                .ForMember(dest => dest.CategoryId, opt => opt.MapFrom(src => src.Category))
                .ForMember(dest => dest.Category, opt => opt.Ignore())
                .ForMember(dest => dest.Image, opt => opt.Ignore());
        }
    }
}
