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


    public AdminManager(IServiceProvider services)
    {
        BottledDrinkManager = services.GetRequiredService<IBottledDrinkManager>();
        CreamManager = services.GetRequiredService<ICreamManager>();
        DessertManager = services.GetRequiredService<IDessertManager>();
        DrinkManager = services.GetRequiredService<IDrinkManager>();
        EspressoManager = services.GetRequiredService<IEspressoManager>();
        FoodInPackageManager = services.GetRequiredService<IFoodInPackageManager>();
        LunchAndBreakfastManager = services.GetRequiredService<ILunchAndBreakfastManager>();
        MilkManager = services.GetRequiredService<IMilkManager>();
        PastryManager = services.GetRequiredService<IPastryManager>();
        SizeManager = services.GetRequiredService<ISizeManager>();
        SyropManager = services.GetRequiredService<ISyropManager>();
        UserManager = services.GetRequiredService<IUserManager>();
    }
}
