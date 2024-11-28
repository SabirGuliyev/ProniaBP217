using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProniaMVC.Areas.Admin.ViewModels;
using ProniaMVC.DAL;

namespace ProniaMVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public ProductController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }


        public async Task<IActionResult> Index()
        {
            var productsVMs=await _context.Products
                .Include(p=>p.Category)
                .Include(p=>p.ProductImages.Where(pi=>pi.IsPrimary==true))
                .Select(p=> new GetProductAdminVM
                {
                    Id= p.Id,
                    Name = p.Name,
                    Price = p.Price,
                    CategoryName = p.Category.Name,
                    Image = p.ProductImages[0].Image
                }

                )
                .ToListAsync();

           
            return View(productsVMs);
        }


        public async Task<IActionResult> Create()
        {
            CreateProductVM productVM = new CreateProductVM
            {

                Categories=await _context.Categories.ToListAsync()
            };
            return View(productVM);
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateProductVM productVM)
        {
            productVM.Categories = await _context.Categories.ToListAsync();

            if (!ModelState.IsValid)
            {
                return View(productVM);
            }
            bool result = productVM.Categories.Any(c => c.Id == productVM.CategoryId);
            if (!result)
            {
                ModelState.AddModelError(nameof(CreateProductVM.CategoryId), "Category does not exist");
                return View(productVM);
            }


            return Content("OK");
        }
    }
}
