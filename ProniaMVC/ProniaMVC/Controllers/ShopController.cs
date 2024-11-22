using Microsoft.AspNetCore.Mvc;

namespace ProniaMVC.Controllers
{
    public class ShopController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
