using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProniaMVC.DAL;
using ProniaMVC.Models;

namespace ProniaMVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly AppDbContext _context;

        public CategoryController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
       {
            List<Category> categories =await _context.Categories.Include(c=>c.Products).ToListAsync();


            return View(categories);
        }

        
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Category category)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            bool result=await _context.Categories.AnyAsync(c=>c.Name.Trim()== category.Name.Trim());

            if (result)
            {
                ModelState.AddModelError("Name", "Category already exists");
                return View();
            }
               
            category.CreatedAt= DateTime.Now;
            

            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();


            return RedirectToAction(nameof(Index));
        }
    }
}
