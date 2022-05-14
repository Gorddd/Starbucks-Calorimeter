using Starbucks_Calorimeter.Models.Entity;

namespace Starbucks_Calorimeter.Managers.Sizes
{
    public interface ISizeManager
    {
        Task<List<Size>> GetAll();
        Task Add(Size size);
        Task Update(Size size);
        Task Delete(int id);
    }
}
