using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebShop.Models.Form;
using WebShop.Services;

namespace WebShop.Controllers
{
    public class LoginController : Controller
    {
        private readonly AuthenticationServies _auth;
        private readonly SignInManager<IdentityUser> _signInManager;

        public LoginController(AuthenticationServies auth, SignInManager<IdentityUser> signInManager)
        {
            _auth = auth;
            _signInManager = signInManager;
        }

        public IActionResult Index(string ReturnUrl = null!)
        {
            var form = new LoginForm { ReturnUrl = ReturnUrl ?? Url.Content("/Home") };

            return View(form);
        }

        [HttpPost]
        public async Task<IActionResult> Index(LoginForm form)
        {
            if (ModelState.IsValid)
            {
                if (await _auth.LoginAsync(form))
                {
                    return LocalRedirect(form.ReturnUrl!);
                }
            }

            ModelState.AddModelError(string.Empty, "Incorrect email or password");
            return View(form);
        }

        [Route("/logout")]
        public async Task<IActionResult> Logout()
        {

            if (_signInManager.IsSignedIn(User))
                await _signInManager.SignOutAsync();

            return LocalRedirect("/home");
        }
    }
}
