using UKitchen.Domain.Data.Dto.ProductDto;

namespace UniversityKitchen.Features.Product;

public interface IProductService
{
    Task<List<GetProductDto>> GetAll();
    Task<GetProductDto> GetById(int id);
    Task<bool> Create(CreateProduct view);
    
}