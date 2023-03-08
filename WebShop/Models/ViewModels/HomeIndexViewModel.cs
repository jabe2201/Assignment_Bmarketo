namespace WebShop.Models.ViewModels
{
    public class HomeIndexViewModel
    {
        public IEnumerable<SmallCardViewModel> BestCollection { get; set; }
        public IEnumerable<MediumCardViewModel> DiscountShowcase { get; set; }
        public IEnumerable<SmallCardViewModel> CarouselCollection { get; set; }
        public IEnumerable<LargeCardViewModel> PopularCollection { get; set; }
    }
}
