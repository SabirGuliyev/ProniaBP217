using Azure;
using Azure.Core;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using ProniaMVC.DAL;
using ProniaMVC.Models;
using ProniaMVC.Services.Interfaces;
using ProniaMVC.ViewModels;
using System.Security.Claims;

namespace ProniaMVC.Services.Implementations
{
    public class LayoutService:ILayoutService
    {
        private readonly AppDbContext _context;

        public LayoutService(AppDbContext context)
        {
            _context = context;
        }


        public async Task<Dictionary<string, string>> GetSettingsAsync()
        {
            Dictionary<string, string> settings = await _context.Settings.ToDictionaryAsync(s => s.Key, s => s.Value);

            return settings;
        }
    }
}
