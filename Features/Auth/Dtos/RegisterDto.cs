using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;
using UniversityKitchen.Data.Enum;

namespace UniversityKitchen.Features.Auth.Dtos;

public class RegisterDto
{
    public string Username { get; set; }
    public string Password { get; set; }
    public string Firstname { get; set; }
    public string Lastname { get; set; }
    public string PhoneNumber { get; set; }
    public RoleEnum SelectedRole { get; set; }
    public List<SelectListItem> Roles { get; set; }
    public RegisterDto()
    {
        Roles = Enum.GetValues(typeof(RoleEnum))    
            .Cast<RoleEnum>()
            .Where(r => r != RoleEnum.SuperAdmin)
            .Select(r => new SelectListItem { Value = ((int)r).ToString(), Text = r.ToString() })
            .ToList();
    }
}