using ProniaMVC.ViewModels;

namespace ProniaMVC.Services.Interfaces
{
    public interface ILayoutService
    {
         Task<Dictionary<string, string>> GetSettingsAsync();

        Task<List<BasketItemVM>> GetBasketAsync();
    }
}
