using AutoMapper;
using Microsoft.EntityFrameworkCore;
using UKitchen.Domain.Data.Dto.AuthDto;
using UKitchen.Domain.Data.Enum;
using UKitchen.Domain.Data.Models;
using UniversityKitchen.Data.Context;
using UniversityKitchen.Exception;

namespace UniversityKitchen.Features.Auth;

public class AuthService(AppDbContext context, IMapper mapper) : IAuthService
{
    
    public Task<bool> Login(LoginDto view)
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