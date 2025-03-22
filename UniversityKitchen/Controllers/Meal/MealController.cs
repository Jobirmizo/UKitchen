using System.Security.Cryptography.X509Certificates;
using Microsoft.AspNetCore.Mvc;
using UKitchen.Domain.Data.Dto.MealDto;
using UniversityKitchen.Features.Meal;
using UniversityKitchen.Features.Meal.Dto;

namespace UniversityKitchen.Controllers.Meal;

[Route("meal")]
public class MealController(IMealService _meal) : Controller
{

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        return View(await _meal.GetAll());
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