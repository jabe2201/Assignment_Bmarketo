using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebShop.Models.Form;
using WebShop.Services;

namespace WebShop.Controllers
{
    public class RegisterController : Controller
    {
        private readonly AuthenticationServies _auth;
        private readonly UserManager<IdentityUser> _userManager;
        public RegisterController(AuthenticationServies auth, UserManager<IdentityUser> userManager)
        {
            _auth = auth;
            _userManager = userManager;
        }

        public IActionResult Index(string ReturnUrl = null!)
        {
            var form = new RegisterForm { ReturnUrl = ReturnUrl ?? Url.Content("/Login") };

            return View(form);
        }

        [HttpPost]
        public async Task<IActionResult> Index(RegisterForm form)
        {
            if (ModelState.IsValid)
            {
                if (await _userManager.Users.AnyAsync(x => x.Email == form.Email))
                {
                    ModelState.AddModelError(string.Empty, "A user with the email already exists.");
                    return View(form);
                }

                if (await _auth.RegisterAsync(form))
                {
                    return LocalRedirect(form.ReturnUrl);
                }
                else
                {
                    return View();
                }
            }

            return View(form);
        }
    }
}
