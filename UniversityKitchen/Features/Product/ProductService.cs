using AutoMapper;
using Microsoft.EntityFrameworkCore;
using UKitchen.Domain.Data.Dto.ProductDto;
using UKitchen.Domain.Data.Enum;
using UniversityKitchen.Data.Context;

namespace UniversityKitchen.Features.Product;

public class ProductService : IProductService
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;
    
    public ProductService(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<GetProductDto>> GetAll()
    {
        var products = await _context.Products.ToListAsync();

        if (!products.Any())
            return new List<GetProductDto>();
        
        return  _mapper.Map<List<GetProductDto>>(products);
    }

    public Task<GetProductDto> GetById(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> Create(CreateProduct view)
    {
        try
        {
            if (view.Exparetion < DateTime.UtcNow)
            {
                view.IsExpired = true;
            }
            view.Exparetion = DateTime.SpecifyKind(view.Exparetion, DateTimeKind.Utc);
            view.DelveredAt = DateTime.SpecifyKind(view.DelveredAt, DateTimeKind.Utc);
        
            var mappedproduct = _mapper.Map<UKitchen.Domain.Data.Models.Product>(view);
            
            await _context.AddAsync(mappedproduct);
            await _context.SaveChangesAsync();
        
            return true;
        }
        catch (System.Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
       
    }

    public async Task<bool> IsLiquid(int id)
    {
        return await _context.Products.
            Where(p => p.Id == id).AnyAsync();
    }

 public List<string> GetProductCategories()
{
    var pCategories = Enum.GetValues(typeof(ProductCategoryEnum))
                          .Cast<ProductCategoryEnum>()
                          .Select(c => c.ToString()) // Convert enum to string
                          .ToList();
    return pCategories;
}
}