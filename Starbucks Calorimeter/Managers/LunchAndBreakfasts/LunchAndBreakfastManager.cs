using Starbucks_Calorimeter.Models;
using Starbucks_Calorimeter.Models.Entity;
using Microsoft.EntityFrameworkCore;

namespace Starbucks_Calorimeter.Managers.LunchAndBreakfasts
{
    public class LunchAndBreakfastManager : ILunchAndBreakfastManager
    {
        private ApplicationContext _context;

        public LunchAndBreakfastManager(ApplicationContext context)
        {
            _context = context;
        }
        public async Task Add(LunchAndBreakfast lunchAndBreakfast)
        {
            _context.LunchAndBreakfasts.Add(lunchAndBreakfast);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var lunchAndBreakfast = _context.LunchAndBreakfasts.FirstOrDefault(lab => lab.Id == id);

            _context.LunchAndBreakfasts.Remove(lunchAndBreakfast);
            await _context.SaveChangesAsync();
        }

        public async Task<List<LunchAndBreakfast>> Filter(string name)
        {
            var lunchAndBreakfasts = await GetAll();

            if (!string.IsNullOrEmpty(name))
            {
                lunchAndBreakfasts = lunchAndBreakfasts.Where(lab => lab.Name == name).ToList();
            }

            return lunchAndBreakfasts;
        }

        public async Task<LunchAndBreakfast> Get(int id)
        {
            return await _context.LunchAndBreakfasts.FirstOrDefaultAsync(lab => lab.Id == id);
        }

        public async Task<LunchAndBreakfast> Get(string name)
        {
            return await _context.LunchAndBreakfasts.FirstOrDefaultAsync(d => d.Name == name);
        }

        public async Task<List<LunchAndBreakfast>> GetAll()
        {
            
            return await _context.LunchAndBreakfasts.AsNoTracking().ToListAsync();

        }

        public async Task Update(LunchAndBreakfast lunchAndBreakfast)
        {
            _context.LunchAndBreakfasts.Update(lunchAndBreakfast);
            await _context.SaveChangesAsync();
        }
    }
}
