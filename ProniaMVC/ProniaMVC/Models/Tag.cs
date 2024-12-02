namespace ProniaMVC.Models
{
    public class Tag:BaseEntity
    {
        public string Name { get; set; }

        //relational
        public List<ProductTag> ProductTags { get; set; }
    }
}
