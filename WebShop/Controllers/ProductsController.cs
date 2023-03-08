using Microsoft.AspNetCore.Mvc;

namespace WebShop.Controllers
{
    public class ProductsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
