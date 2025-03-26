using UKitchen.Domain.Data.Dto.AuthDto;

namespace UniversityKitchen.Features.Auth;

public interface IAuthService
{
    Task<bool> Login(LoginDto view);
    Task<bool> Register(RegisterDto view);
}