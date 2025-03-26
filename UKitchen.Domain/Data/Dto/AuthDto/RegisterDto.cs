namespace UKitchen.Domain.Data.Dto.AuthDto;

public class RegisterDto
{
    public string Username { get; set; }  = null!;
    public string Password { get; set; }   = null!;
    public string Firstname { get; set; }  = null!;
    public string Lastname { get; set; }   = null!;
    public string PhoneNumber { get; set; }   = null!;
    public string CountryCode { get; set; } = "+998";
}