using ProniaMVC.Models;

namespace ProniaMVC.ViewModels
{
    public class OrderVM
    {
        public string Address { get; set; }
        public List<BasketInOrderVM>? BasketInOrderVMs { get; set; }
    }
}
