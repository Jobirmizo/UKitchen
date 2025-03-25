using System;
using UniversityKitchen.Data.Enum;

namespace UniversityKitchen.Data.Models;

public class User
{
    public int Id { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public string Firstname { get; set; }
    public string Lastname { get; set; }
    public bool IsVerified { get; set; }
    public int? Year { get; set; }
    public RoleEnum RoleEnum { get; set; } 
    public string PhoneNumber { get; set; }
    public string? Email { get; set; }
    public DateTime? CreatedAt { get; set; }
}
