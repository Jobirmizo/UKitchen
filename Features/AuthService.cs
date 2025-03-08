using System;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using UniversityKitchen.Data.Context;
using UniversityKitchen.Data.Enum;
using UniversityKitchen.Data.Models;
using UniversityKitchen.Exception;
using UniversityKitchen.Features.Auth;
using UniversityKitchen.Features.Auth.Dtos;

namespace UniversityKitchen.Features;

public class AuthService(AppDbContext context, IMapper mapper) : IAuthService
{
    
    public async Task<bool> Login(LoginDto view)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> Register(RegisterDto view)
    {
        bool isUserExist = await context.Users.AnyAsync(u => u.Username == view.Username && u.Password == view.Password);

        if (isUserExist)
            throw new Conflict("User with this username or phonenumber already exists");
        
        var user = mapper.Map<User>(view);
        
        user.CreatedAt = DateTime.UtcNow;
        user.RoleEnum = RoleEnum.Admin;
        
        await context.Users.AddAsync(user);
        await context.SaveChangesAsync();
        return true;
    }
}