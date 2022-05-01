using Starbucks_Calorimeter.Models.Entity;

namespace Starbucks_Calorimeter.Managers.Sizes
{
    public interface ISizeManager
    {
        Task<List<Size>> GetAll();
    }
}
