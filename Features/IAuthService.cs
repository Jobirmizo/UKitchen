using System.Threading.Tasks;
using UniversityKitchen.Features.Auth;
using UniversityKitchen.Features.Auth.Dtos;

namespace UniversityKitchen.Features;

public interface IAuthService
{
    Task<bool> Login(LoginDto view);
    Task<bool> Register(RegisterDto view);
}