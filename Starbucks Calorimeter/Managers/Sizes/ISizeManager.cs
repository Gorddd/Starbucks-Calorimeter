using Starbucks_Calorimeter.Models.Entity;

namespace Starbucks_Calorimeter.Managers;

public interface ISizeManager
{
    Task<List<Size>> GetAll();
    Task<Size> GetSize(int id);
    Task<Size> GetSize(string name);     
    Task AddSize(Size size);
    Task DeleteSize(int id);
    Task UpdateSize(Size size);
    Task<List<Size>> Filter(string name);
}
