using AutoMapper;
using UniversityKitchen.Data.Models;
using UniversityKitchen.Features.Product.Dto;

namespace UniversityKitchen.Features.Product;

public class ProductMapper : Profile
{
    public ProductMapper()
    {
        CreateMap<Data.Models.Product, GetProductDto>()
            .ForMember(dest => dest.ProductCategory, opt => opt.MapFrom(src => src.ProductCategoryEnum.ToString()));
        CreateMap<CreateProduct, Data.Models.Product>();
;
    }
}