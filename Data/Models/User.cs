using System;
using Microsoft.AspNetCore.Identity;
using UniversityKitchen.Data.Enum;

namespace UniversityKitchen.Data.Models;

public class User : IdentityUser
{
    public string Firstname { get; set; }
    public string Lastname { get; set; }
    public bool IsVerified { get; set; }
    public int? Year { get; set; }
    public RoleEnum RoleEnum { get; set; } 
    public string PhoneNumber { get; set; }
    public string? Email { get; set; }
    public DateTime? CreatedAt { get; set; }
}
