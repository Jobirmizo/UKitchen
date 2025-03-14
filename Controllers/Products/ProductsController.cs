using Microsoft.AspNetCore.Mvc;
using UniversityKitchen.Data.Context;
using UniversityKitchen.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace UniversityKitchen.Controllers.Products
{
    public class ProductsController : Controller
    {
        private readonly AppDbContext _context;

        public ProductsController(AppDbContext context)
        {
            _context = context;
        }

        // Mahsulotlar ro‘yxati
        public async Task<IActionResult> Index()
        {
            return View(await _context.Products.ToListAsync());
        }

        // Yangi mahsulot qo‘shish (GET)
        public IActionResult Create()
        {
            return View();
        }

        // Yangi mahsulot qo‘shish (POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Price,Quantity")] Product product)
        {
            if (ModelState.IsValid)
            {
                _context.Add(product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }
    }
}
