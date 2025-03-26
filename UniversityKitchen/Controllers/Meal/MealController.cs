using Microsoft.AspNetCore.Mvc;
using UKitchen.Domain.Data.Dto.MealDto;
using UniversityKitchen.Features.Meal;

namespace UniversityKitchen.Controllers.Meal;

[Route("meal")]
public class MealController(IMealService _meal) : Controller
{

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        await _meal.GetAll();
        return View();
    }

    [HttpGet("create")]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost("create")]
    public async Task<IActionResult> Create(CreateMealDto dto)
    {
        await _meal.Create(dto);
        TempData["Success"] = "Product created successfully!";
        return RedirectToAction("Index"); 
    }

    [HttpPost("upload-file")]
    public async Task<IActionResult> UploadFile([FromForm] IFormFile file)
    {
        await _meal.UploadMealFile(file);
        TempData["Success"] = "Product created successfully!";
        return RedirectToAction("Index"); 
    }
}