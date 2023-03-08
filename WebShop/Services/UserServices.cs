using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebShop.Context;
using WebShop.Models.Identity;
using WebShop.Models.ViewModels;

namespace WebShop.Services
{
    public class UserServices
    {
        private readonly IdentityContext _identityContext;
        private readonly UserManager<IdentityUser> _userManager;

        public UserServices(IdentityContext identityContext, UserManager<IdentityUser> userManager)
        {
            _identityContext = identityContext;
            _userManager = userManager;
        }

        public async Task<AccountViewModel> GetUserAccountAsync(string userName)
        {
            var identityUser = await _userManager.Users.FirstOrDefaultAsync(x => x.UserName == userName);
            if(identityUser != null) 
            {
                var identityUserProfile = await _identityContext.Profiles.FirstOrDefaultAsync(x => x.UserId == identityUser.Id);
                if(identityUserProfile != null)
                {
                    return new AccountViewModel
                    {
                        FirstName = identityUserProfile.FirstName,
                        LastName = identityUserProfile.LastName,
                        Email = identityUser.Email!,
                        PhoneNumber = identityUser.PhoneNumber,
                        StreetName= identityUserProfile.StreetName,
                        City = identityUserProfile.City,
                        PostalCode = identityUserProfile.PostalCode
                    };
                }
            }
            return null!;
        }
    }
}
