using Starbucks_Calorimeter.Models.Entity;

namespace Starbucks_Calorimeter.Managers.FoodInPackages
{
    public interface IFoodInPackageManager
    {
        Task<List<FoodInPackage>> GetAll(); //AsNoTracking
        Task<FoodInPackage> Get(int id);
        Task Add(FoodInPackage foodInPackage);
        Task Update(FoodInPackage foodInPackage);
        Task Delete(int id);
        Task<List<FoodInPackage>> Filter(string name);
    }
}
