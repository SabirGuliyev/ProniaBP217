using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProniaMVC.DAL;

namespace ProniaMVC.ViewComponents
{
    public class FooterViewComponent:ViewComponent
    {
        private readonly AppDbContext _context;

        public FooterViewComponent(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            Dictionary<string,string> settings=await _context.Settings.ToDictionaryAsync(s=>s.Key,s=>s.Value);

            return View(settings);

            //return View(Task.FromResult(settings));
        }
    }
}
