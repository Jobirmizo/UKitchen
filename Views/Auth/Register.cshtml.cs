using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UniversityKitchen.Data.Context;
using UniversityKitchen.Data.Models;
using UniversityKitchen.Features.Auth.Dtos;

namespace UniversityKitchen.Views.Auth;

public class Register(AppDbContext context, IMapper mapper) : PageModel
{

    private readonly AppDbContext _context = context;
    private readonly IMapper _mapper = mapper;
    
    public RegisterDto RegisterDto { get; set; } = new RegisterDto();

    public async Task<IActionResult> onPost()
    {
        if (ModelState.IsValid)
            return Page();
        
        var user = _mapper.Map<User>(RegisterDto);
        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();

        return RedirectToAction("/Success");
    }
    
    
}