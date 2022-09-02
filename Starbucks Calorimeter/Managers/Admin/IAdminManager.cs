namespace Starbucks_Calorimeter.Managers;

public interface IAdminManager
{
    IBottledDrinkManager BottledDrinkManager { get; }
    ICreamManager CreamManager { get; }
    IDessertManager DessertManager { get; }
    IDrinkManager DrinkManager { get; }
    IEspressoManager EspressoManager { get; }
    IFoodInPackageManager FoodInPackageManager { get; }
    ILunchAndBreakfastManager LunchAndBreakfastManager { get; }
    IMilkManager MilkManager { get; } 
    IPastryManager PastryManager { get; }
    ISizeManager SizeManager { get; }
    ISyropManager SyropManager { get; }
    IUserManager UserManager { get; }
}
