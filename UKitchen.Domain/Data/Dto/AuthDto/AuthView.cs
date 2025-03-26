namespace UKitchen.Domain.Data.Dto.AuthDto;

public class AuthLoginView
{
    public LoginDto LoginDto { get; set; } = null!;
    public RegisterDto RegisterDto { get; set; } = null!;
}