using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UniversityKitchen.Features;
using UniversityKitchen.Features.Auth;
using UniversityKitchen.Features.Auth.Dtos;

namespace UniversityKitchen.Controllers.Auth;

[Route("auth")]
public class AuthController(IAuthService auth) : Controller
{
    [HttpGet("register")]
    public IActionResult Register()
    {
        var model = new RegisterDto(); 
        return View(model);
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterDto model)
    {
        var success = await auth.Register(model);
        if (success)
            return RedirectToAction("Login", "Auth");

        return View();
    }
    
    [HttpGet("login")]
    public IActionResult Login()
    {
        var model = new LoginDto();
        return View(model);
    }

    [HttpPost("login")]
    public IActionResult Login(LoginDto dto)
    {
        if(ModelState.IsValid)
            return RedirectToAction("Index", "Home");

        return View(dto);
    }
    
}