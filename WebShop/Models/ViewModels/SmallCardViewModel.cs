namespace WebShop.Models.ViewModels
{
    public class SmallCardViewModel
    {
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public decimal DiscountPrice { get; set; }
        public string ImageSrc { get; set; } = string.Empty;
        public string ImageAlt { get; set; } = string.Empty;
    }
}
