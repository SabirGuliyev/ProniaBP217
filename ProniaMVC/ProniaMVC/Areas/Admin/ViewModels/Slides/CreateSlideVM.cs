using System.ComponentModel.DataAnnotations.Schema;

namespace ProniaMVC.Areas.Admin.ViewModels
{
    public class CreateSlideVM
    {

        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string Description { get; set; }

        public int Order { get; set; }

        public IFormFile Photo { get; set; }
    }
}
