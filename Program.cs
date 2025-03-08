using System.Text;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Identity;
using UniversityKitchen.Data;
using UniversityKitchen.Data.Context;
using UniversityKitchen.Data.Models;
using UniversityKitchen.Exception;
using UniversityKitchen.Features;
using UniversityKitchen.Features.Auth;

var builder = WebApplication.CreateBuilder(args);

#region JWT
builder.Services.AddControllersWithViews();

#endregion
#region DB

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("Connection")));
#endregion

#region Services
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddControllersWithViews();
builder.Services.AddSession();
builder.Services.AddRazorPages();
builder.Services.AddAutoMapper(typeof(MappingProfile));


#endregion

var app = builder.Build();
app.UseMiddleware<ExeptionMiddleware>();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseSession();
app.UseRouting();

app.UseAuthorization();
app.MapControllers();
app.MapStaticAssets();

app.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();
app.MapRazorPages();


app.Run();