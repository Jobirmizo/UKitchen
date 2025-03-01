using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace UniversityKitchen.Controller;

public class AuthController : Microsoft.AspNetCore.Mvc.Controller
{

    public IActionResult Login()
    {
        return View();
    }
}