using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using Starbucks_Calorimeter.Managers.BottledDrinks;
using Starbucks_Calorimeter.Managers.Creams;
using Starbucks_Calorimeter.Managers.Desserts;
using Starbucks_Calorimeter.Managers.Drinks;
using Starbucks_Calorimeter.Managers.Espressoes;
using Starbucks_Calorimeter.Managers.FoodInPackages;
using Starbucks_Calorimeter.Managers.LunchAndBreakfasts;
using Starbucks_Calorimeter.Managers.Milks;
using Starbucks_Calorimeter.Managers.Pastries;
using Starbucks_Calorimeter.Managers.Sizes;
using Starbucks_Calorimeter.Managers.Syrops;
using Starbucks_Calorimeter.Managers.Users;
using Starbucks_Calorimeter.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddSingleton<DrinkView>();
builder.Services.AddTransient<IUserManager, UserManager>();
builder.Services.AddTransient<ISizeManager, SizeManager>();
builder.Services.AddTransient<ISyropManager, SyropManager>();
builder.Services.AddTransient<ILunchAndBreakfastManager, LunchAndBreakfastManager>();
builder.Services.AddTransient<IFoodInPackageManager, FoodInPackageManager>();
builder.Services.AddTransient<IEspressoManager, EspressoManager>();
builder.Services.AddTransient<IDessertManager, DessertManager>();
builder.Services.AddTransient<ICreamManager, CreamManager>();
builder.Services.AddTransient<IBottledDrinkManager, BottledDrinkManager>();
builder.Services.AddTransient<IMilkManager, MilkManager>();
builder.Services.AddTransient<IDrinkManager, DrinkManager>();
builder.Services.AddTransient<IPastryManager, PastryManager>();

// Создаем контекст. Соединяем с БД
var connection = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(connection));

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Admin/Login";
        options.AccessDeniedPath = "/Admin/Login";
    });
builder.Services.AddAuthorization();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
