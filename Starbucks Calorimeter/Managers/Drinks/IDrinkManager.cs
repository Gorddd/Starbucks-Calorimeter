using Starbucks_Calorimeter.Models.Entity;

namespace Starbucks_Calorimeter.Managers.Drinks
{
    public interface IDrinkManager
    {
        Task<List<Drink>> GetAll(); //AsNoTracking и Load 
        Task<Drink> GetDrink(int id);
        Task AddDrink(Drink drink);
        Task UpdateDrink(Drink drink);
        Task DeleteDrink(int id);
        Task<List<Drink>> Filter(string name); 
    }
}
