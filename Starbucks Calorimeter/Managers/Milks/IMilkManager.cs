using Starbucks_Calorimeter.Models.Entity;

namespace Starbucks_Calorimeter.Managers;

public interface IMilkManager
{
    Task<List<Milk>> GetAll(); //AsNoTracking
    Task<Milk> Get(int id);
    Task<Milk> Get(string name);
    Task Add(Milk milk);
    Task Update(Milk milk);
    Task Delete(int id);
    Task<List<Milk>> Filter(string name);
}
