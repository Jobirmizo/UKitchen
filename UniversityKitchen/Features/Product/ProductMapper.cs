using AutoMapper;
using UKitchen.Domain.Data.Dto.ProductDto;

namespace UniversityKitchen.Features.Product;

public class ProductMapper : Profile
{
    public ProductMapper()
    {
        CreateMap<UKitchen.Domain.Data.Models.Product, GetProductDto>()
            .ForMember(dest => dest.ProductCategory, opt => opt.MapFrom(src => src.ProductCategoryEnum.ToString()));
        CreateMap<CreateProduct, UKitchen.Domain.Data.Models.Product>();
;
    }
}