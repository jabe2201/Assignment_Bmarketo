using Microsoft.EntityFrameworkCore;
using WebShop.Context;
using WebShop.Models;
using WebShop.Models.ViewModels;

namespace WebShop.Services
{
    public class ProductService
    {
        private readonly DataContext _dataContext;

        public ProductService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<HomeIndexViewModel> GetHomeIndexAsync()
        {
            var homeIndexViewModel = new HomeIndexViewModel();

            var products = await _dataContext.Products
                .Include(x => x.Images)
                .Include(x => x.Tags)
                .Include(x => x.Description)
                .Include(x => x.Review)
                .ToListAsync();

            var _bestCollection = new List<SmallCardViewModel>();
            var _discountShowcaseCollection = new List<MediumCardViewModel>();
            var _carouselCollection = new List<SmallCardViewModel>();
            var _popularCollection = new List<LargeCardViewModel>();

            foreach (var product in products) 
            {
                var tag = product.Tags.FirstOrDefault(x => x.TagId == 1);

                if(tag != null)
                {
                    var _image = product.Images.FirstOrDefault(x => x.Product.ProductId == product.ProductId);
                    if(_image != null)
                    {
                        _bestCollection.Add(new SmallCardViewModel
                        {
                            Name = product.Name,
                            Price = product.Price,
                            DiscountPrice = product.DiscountPrice,
                            ImageSrc = _image.ImageSrc,
                            ImageAlt = _image.ImageAlt
                        });
                    }
                }
            }
            if(_bestCollection != null)
            {
                homeIndexViewModel.BestCollection = _bestCollection;
            }

            foreach (var product in products)
            {
                var tag = product.Tags.FirstOrDefault(x => x.TagId == 3);

                if (tag != null)
                {
                    var _image = product.Images.FirstOrDefault(x => x.Product.ProductId == product.ProductId);
                    if (_image != null)
                    {
                        _discountShowcaseCollection.Add(new MediumCardViewModel
                        {
                            Name = product.Name,
                            Price = product.Price,
                            DiscountPrice = product.DiscountPrice,
                            ImageSrc = _image.ImageSrc,
                            ImageAlt = _image.ImageAlt
                        });
                    }
                }
            }
            if (_discountShowcaseCollection != null)
            {
                homeIndexViewModel.DiscountShowcase = _discountShowcaseCollection;
            }

            foreach (var product in products)
            {
                var tag = product.Tags.FirstOrDefault(x => x.TagId == 2);

                if (tag != null)
                {
                    var _image = product.Images.FirstOrDefault(x => x.Product.ProductId == product.ProductId);
                    if (_image != null)
                    {
                        _carouselCollection.Add(new SmallCardViewModel
                        {
                            Name = product.Name,
                            Price = product.Price,
                            DiscountPrice = product.DiscountPrice,
                            ImageSrc = _image.ImageSrc,
                            ImageAlt = _image.ImageAlt
                        });
                    }
                }
            }
            if (_bestCollection != null)
            {
                homeIndexViewModel.CarouselCollection = _carouselCollection;
            }

            foreach (var product in products)
            {
                var tag = product.Tags.FirstOrDefault(x => x.TagId == 4);

                if (tag != null)
                {
                    var _image = product.Images.FirstOrDefault(x => x.Product.ProductId == product.ProductId);
                    
                    
                    if (_image != null)
                    {
                        _popularCollection.Add(new LargeCardViewModel
                        {
                            Name = product.Name,
                            ImageSrc = _image.ImageSrc,
                            ImageAlt = _image.ImageAlt,
                            Description = product.Description.LongDescription,
                            NmbOfReviews = 1
                        }); 
                    }
                }
            }
            if (_popularCollection != null)
            {
                homeIndexViewModel.PopularCollection = _popularCollection;
            }

            return homeIndexViewModel;
        } 
    }
}
