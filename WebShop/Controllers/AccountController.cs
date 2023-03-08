using Microsoft.AspNetCore.Mvc;
using WebShop.Services;

namespace WebShop.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserServices _userServices;

        public AccountController(UserServices userServices)
        {
            _userServices = userServices;
        }

        public async Task<IActionResult> Index()
        {
            var accountViewModel = await _userServices.GetUserAccountAsync(User.Identity!.Name!);
            return View(accountViewModel);
        }
    }
}
