using Microsoft.AspNetCore.Mvc;
using UKitchen.Domain.Data.Dto.ProductDto;
using UniversityKitchen.Features.Product;


namespace UniversityKitchen.Controllers.Products;

[Route("products")]

public class ProductsController(IProductService _product) : Controller
{
    
    [HttpGet("get-all")]
    public async Task<IActionResult> Index()
    {
        return View(await _product.GetAll());
    }
    
    [HttpGet("create")] 
    public IActionResult Create()
    {
        return View();
    }

    
    [HttpPost("create")]
    public async Task<IActionResult> Create(CreateProduct view)
    {
        await _product.Create(view);
        TempData["Success"] = "Product created successfully!";
        return RedirectToAction("Index"); 
    }

    
}

