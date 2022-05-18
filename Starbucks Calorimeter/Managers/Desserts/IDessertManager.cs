using Starbucks_Calorimeter.Models.Entity;

namespace Starbucks_Calorimeter.Managers.Desserts
{
    public interface IDessertManager
    {
        Task<List<Dessert>> GetAll(); //AsNoTracking
        Task<Dessert> Get(int id);
        Task<Dessert> Get(string name);
        Task Add(Dessert dessert);
        Task Update(Dessert dessert);
        Task Delete(int id);
        Task<List<Dessert>> Filter(string name);
    }
}
