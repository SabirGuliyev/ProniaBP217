using ProniaMVC.Models;

namespace ProniaMVC.ViewModels
{
    public class HomeVM
    {

        public List<Slide> Slides { get; set; }
        public List<Product> Products { get; set; }
        public List<Product> NewProducts { get; set; }
    }
}
