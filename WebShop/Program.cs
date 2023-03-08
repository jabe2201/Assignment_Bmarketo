using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebShop.Context;
using WebShop.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddScoped<AuthenticationServies>();
builder.Services.AddScoped<ProductService>();
builder.Services.AddScoped<UserServices>();
builder.Services.AddDbContext<DataContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("Sql")));
builder.Services.AddDbContext<IdentityContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("Identity")));
builder.Services.AddIdentity<IdentityUser, IdentityRole>(x =>
{
    x.Password.RequiredLength = 8;
    x.User.RequireUniqueEmail = true;
    x.SignIn.RequireConfirmedAccount = false;
}).AddEntityFrameworkStores<IdentityContext>();
builder.Services.ConfigureApplicationCookie(x =>
{
    x.LoginPath = "/Account/SignIn";
    x.AccessDeniedPath = "/Errors/AccessDenied";
});


var app = builder.Build();
app.UseHsts();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
