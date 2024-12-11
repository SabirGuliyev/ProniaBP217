using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProniaMVC.DAL;
using ProniaMVC.Models;
using ProniaMVC.Utilities.Enums;

namespace ProniaMVC.ViewComponents
{
    public class ProductViewComponent:ViewComponent
    {
        private readonly AppDbContext _context;

        public ProductViewComponent(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync(SortType sortType)
        {

            List<Product> products = null;
            switch (sortType)
            {
                case SortType.Name:
                    products= await _context.Products
                        .OrderBy(p=>p.Name)
                        .Take(8)
                        .Include(p => p.ProductImages.Where(pi => pi.IsPrimary != null))
                        .ToListAsync();
                    break;
                case SortType.Price:
                    products= await _context.Products
                        .OrderByDescending(p => p.Price)
                        .Take(8)
                        .Include(p => p.ProductImages.Where(pi => pi.IsPrimary != null))
                        .ToListAsync();
                    break;
                case SortType.Date:
                    products = await _context.Products
                       .OrderByDescending(p => p.CreatedAt)
                       .Take(8)
                       .Include(p => p.ProductImages.Where(pi => pi.IsPrimary != null))
                       .ToListAsync();
                    break;
            }
            
            return View(products);
        }
    }
}
