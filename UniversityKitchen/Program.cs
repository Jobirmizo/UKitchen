using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using UniversityKitchen.Data.Context;
using UniversityKitchen.Exception;
using UniversityKitchen.Features;
using UniversityKitchen.Features.Auth;
using UniversityKitchen.Features.Company;
using UniversityKitchen.Features.Meal;
using UniversityKitchen.Features.Product;
using UniversityKitchen.Features.UrlGenerator;
using UniversityKitchen.Features.ImportFile;
using UniversityKitchen.Service;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
#region DB
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("Connection")));
#endregion
#region Services
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<ICompanyService, CompanyService>();
builder.Services.AddScoped<IMealService, MealService>();
builder.Services.AddScoped<IExcelService, ExcelService>();
builder.Services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();
builder.Services.AddScoped<IUrlGenerator, UrlGenerator>();
builder.Services.AddAutoMapper(typeof(MappingProfile));
builder.Services.AddSingleton<IMinioService, MinioService>();
builder.Services.AddControllersWithViews();
builder.Services.AddSession();
builder.Services.AddRazorPages();
#endregion
var app = builder.Build();
app.UseMiddleware<ExeptionMiddleware>();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseSession();
app.UseRouting();
app.UseStaticFiles();


app.UseAuthorization();
app.MapControllers();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();


app.Run();