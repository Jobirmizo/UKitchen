using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using UniversityKitchen.Data.Enum;

namespace UniversityKitchen.Features.Auth.Dtos;

public class RegisterDto
{
    public string Username { get; set; }
    public string Password { get; set; }
    public string Firstname { get; set; }
    public string Lastname { get; set; }
    public string PhoneNumber { get; set; }
    public string CountryCode { get; set; } = "+998";
}