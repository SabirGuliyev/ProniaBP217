using ProniaMVC.ViewModels;

namespace ProniaMVC.Services.Interfaces
{
    public interface IBasketService
    {
        Task<List<BasketItemVM>> GetBasketAsync();
    }
}
