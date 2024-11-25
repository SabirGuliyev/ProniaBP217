using System.ComponentModel.DataAnnotations;

namespace ProniaMVC.Models
{
    public class Category:BaseEntity
    {
       
        [MaxLength(30,ErrorMessage ="Agilli ol 30den coxma olmaz AUYE")]
        public string Name { get; set; }

        //relational
        public List<Product>? Products { get; set; }
    }
}
