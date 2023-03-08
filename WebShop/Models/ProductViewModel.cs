namespace WebShop.Models
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public List<string> ImageSrc { get; set; } = new();
        public List<string> ImageAlt { get; set; } = new();
        public string ShortDescription { get; set; } = string.Empty;
        public string LongDescription { get; set; } = string.Empty;
        public List<string> Tags { get; set; } = new(); 
        public string? Review { get; set; } 
    }
}
