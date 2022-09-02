namespace Starbucks_Calorimeter.Managers;

public class AdminManager : IAdminManager
{
    public IBottledDrinkManager BottledDrinkManager { get; }

    public ICreamManager CreamManager { get; }

    public IDessertManager DessertManager { get; }

    public IDrinkManager DrinkManager { get; }

    public IEspressoManager EspressoManager { get; }

    public IFoodInPackageManager FoodInPackageManager { get; }

    public ILunchAndBreakfastManager LunchAndBreakfastManager { get; }

    public IMilkManager MilkManager { get; }

    public IPastryManager PastryManager { get; }

    public ISizeManager SizeManager { get; }

    public ISyropManager SyropManager { get; }

    public IUserManager UserManager { get; }


    public AdminManager(IApplicationBuilder app)
    {
        BottledDrinkManager = app.ApplicationServices.GetRequiredService<IBottledDrinkManager>();
        CreamManager = app.ApplicationServices.GetRequiredService<ICreamManager>();
        DessertManager = app.ApplicationServices.GetRequiredService<IDessertManager>();
        DrinkManager = app.ApplicationServices.GetRequiredService<IDrinkManager>();
        EspressoManager = app.ApplicationServices.GetRequiredService<IEspressoManager>();
        FoodInPackageManager = app.ApplicationServices.GetRequiredService<IFoodInPackageManager>();
        LunchAndBreakfastManager = app.ApplicationServices.GetRequiredService<ILunchAndBreakfastManager>();
        MilkManager = app.ApplicationServices.GetRequiredService<IMilkManager>();
        PastryManager = app.ApplicationServices.GetRequiredService<IPastryManager>();
        SizeManager = app.ApplicationServices.GetRequiredService<ISizeManager>();
        SyropManager = app.ApplicationServices.GetRequiredService<ISyropManager>();
        UserManager = app.ApplicationServices.GetRequiredService<IUserManager>();
    }
}
