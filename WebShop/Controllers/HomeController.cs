using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebShop.Context;
using WebShop.Models;
using WebShop.Models.ViewModels;
using WebShop.Services;

namespace WebShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly DataContext _dataContext;
        private readonly ProductService _productService;

        public HomeController(DataContext dataContext, ProductService productService)
        {
            _dataContext = dataContext;
            _productService = productService;
        }

        public async Task<IActionResult> Index()
        {
            var homeIndexViewModel = await _productService.GetHomeIndexAsync();
            //var _products = _dataContext.Products
            //        .Include(x => x.Images)
            //        .Include(x => x.Description)
            //        .Include(x => x.Tags)
            //        .Include(x => x.Review);

            //var products = new List<ProductViewModel>();
            //foreach (var product in _products)
            //{
            //    products.Add(new ProductViewModel
            //    {
            //        Name = product.Name,
            //        Price = product.Price,
            //        ImageSrc = product.Images.Select(x => x.ImageSrc).ToList(),
            //        ImageAlt = product.Images.Select(x => x.ImageAlt).ToList(),
            //        ShortDescription = product.Description.ShortDescription,
            //        LongDescription = product.Description.LongDescription,
            //        Tags = product.Tags.Select(x => x.Tag).ToList(),
            //        Review = product.Review.Review
            //    });
            //}

            //var _product = _dataContext.Products.Find(8);
            //_dataContext.SaveChanges();

            
            return View(homeIndexViewModel);
        }
    }
}
