using ProniaMVC.Models;
using System.ComponentModel.DataAnnotations;

namespace ProniaMVC.Areas.Admin.ViewModels
{
    public class CreateProductVM
    {
        public string Name { get; set; }
        [Required]
        public decimal? Price { get; set; }
        public string Description { get; set; }
        public string SKU { get; set; }
        [Required]
        public int? CategoryId { get; set; }

        public List<Category>? Categories { get; set; }


    }
}
