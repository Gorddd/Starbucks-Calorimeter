using Starbucks_Calorimeter.Models.Entity;

namespace Starbucks_Calorimeter.Managers.LunchAndBreakfasts
{
    public interface ILunchAndBreakfastManager
    {
        Task<List<LunchAndBreakfast>> GetAll(); //AsNoTracking
        Task<LunchAndBreakfast> Get(int id);
        Task<LunchAndBreakfast> Get(string name);
        Task Add(LunchAndBreakfast lunchAndBreakfast);
        Task Update(LunchAndBreakfast lunchAndBreakfast);
        Task Delete(int id);
        Task<List<LunchAndBreakfast>> Filter(string name);
    }
}
