using Microsoft.AspNetCore.Mvc;
using UniversityKitchen.Features.Auth;

namespace UniversityKitchen.wwwroot.Controller;

public class AuthController : Microsoft.AspNetCore.Mvc.Controller
{

    public IActionResult Login()
    {
        return View(new LoginView());
    }
}