using Starbucks_Calorimeter.Managers;

namespace Starbucks_Calorimeter.Extensions;

public static class ServiceProviderExtensions
{
    public static void AddStarbucksServices(this IServiceCollection services)
    {
        services.AddSingleton<DrinkView>();
        services.AddTransient<IUserManager, UserManager>();
        services.AddTransient<ISizeManager, SizeManager>();
        services.AddTransient<ISyropManager, SyropManager>();
        services.AddTransient<ILunchAndBreakfastManager, LunchAndBreakfastManager>();
        services.AddTransient<IFoodInPackageManager, FoodInPackageManager>();
        services.AddTransient<IEspressoManager, EspressoManager>();
        services.AddTransient<IDessertManager, DessertManager>();
        services.AddTransient<ICreamManager, CreamManager>();
        services.AddTransient<IBottledDrinkManager, BottledDrinkManager>();
        services.AddTransient<IMilkManager, MilkManager>();
        services.AddTransient<IDrinkManager, DrinkManager>();
        services.AddTransient<IPastryManager, PastryManager>();
    }
}
