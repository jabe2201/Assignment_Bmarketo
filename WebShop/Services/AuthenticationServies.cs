using Microsoft.AspNetCore.Identity;
using WebShop.Context;
using WebShop.Models.Form;
using WebShop.Models.Identity;

namespace WebShop.Services
{
    public class AuthenticationServies
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly IdentityContext _context;

        public AuthenticationServies(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, IdentityContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
        }

        public async Task<bool> RegisterAsync(RegisterForm form)
        {
            var identityUser = new IdentityUser { UserName = form.Email, Email = form.Email, PhoneNumber = form.PhoneNumber };
            var identityProfile = new IdentityUserProfile
            {
                UserId = identityUser.Id,
                FirstName = form.FirstName,
                LastName = form.LastName,
                StreetName = form.StreetName,
                PostalCode = form.PostalCode,
                City = form.City,
                Company = form.Company
            };

            var result = await _userManager.CreateAsync(identityUser, form.Password);
            if(result.Succeeded)
            {
                _context.Profiles.Add(identityProfile);
                await _context.SaveChangesAsync();

                return true;
            }

            return false;
        }

        public async Task<bool> LoginAsync(LoginForm form, bool keepMeLoggedIn = false)
        {
            var result = await _signInManager.PasswordSignInAsync(form.Email, form.Password, keepMeLoggedIn, false);
            return result.Succeeded;
        }
    }
}
