using Microsoft.EntityFrameworkCore;
using UniversityKitchen.Data.Models;

namespace UniversityKitchen.Data.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    { }
    
    
    public DbSet<User> Users { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Meal> Meals { get; set; }
    public DbSet<Company> Companies { get; set; }
    
}
