using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ProniaMVC.Controllers;
using ProniaMVC.DAL;
using ProniaMVC.Models;
using ProniaMVC.Services.Implementations;
using ProniaMVC.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddSession(opt=>opt.IdleTimeout=TimeSpan.FromSeconds(60));
//builder.Services.AddScoped<IHttpContextAccessor,HttpContextAccessor>();

builder.Services.AddHttpContextAccessor();



builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AppDbContext>(opt =>

     opt.UseSqlServer(builder.Configuration.GetConnectionString("Default"))

);

builder.Services.AddIdentity<AppUser, IdentityRole>(opt =>
{
    opt.Password.RequiredLength = 8;
    opt.Password.RequireNonAlphanumeric = false;

    //opt.User.AllowedUserNameCharacters = "qwertyuioasdfghjkl;zxcvbnm";
    opt.User.RequireUniqueEmail = true;

    opt.Lockout.AllowedForNewUsers = true;
    opt.Lockout.MaxFailedAccessAttempts = 3;
    opt.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(3);
}).AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();

builder.Services.AddScoped<ILayoutService,LayoutService>();
builder.Services.AddScoped<IBasketService,BasketService>();
var app = builder.Build();

//app.UseSession();
app.UseAuthentication();
app.UseAuthorization();

app.UseStaticFiles();


app.MapControllerRoute(
    "admin",
    "{area:exists}/{controller=home}/{action=index}/{id?}"

    );
app.MapControllerRoute(
    "default",
    "{controller=home}/{action=index}/{id?}"

    );

app.Run();
