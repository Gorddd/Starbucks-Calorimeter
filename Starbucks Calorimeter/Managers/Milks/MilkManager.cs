using Microsoft.EntityFrameworkCore;
using Starbucks_Calorimeter.Models;
using Starbucks_Calorimeter.Models.Entity;

namespace Starbucks_Calorimeter.Managers.Milks
{
    public class MilkManager : IMilkManager
    {
        private ApplicationContext _context;

        public MilkManager(ApplicationContext context)
        {
            _context = context;
        }
        public async Task Add(Milk milk)
        {
            _context.Milks.Add(milk);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var milk = _context.Milks.FirstOrDefault(m => m.Id == id);

            _context.Milks.Remove(milk);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Milk>> Filter(string name)
        {
            var milk = await GetAll();

            if (!string.IsNullOrEmpty(name))
            {
                milk = milk.Where(s => s.Name == name).ToList();
            }

            return milk;
        }

        public async Task<Milk> Get(int id)
        {
            return await _context.Milks.FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<Milk> Get(string name)
        {
            return await _context.Milks.FirstOrDefaultAsync(d => d.Name == name);
        }

        public async Task<List<Milk>> GetAll()
        {
            return await _context.Milks.AsNoTracking().ToListAsync();
        }

        public async Task Update(Milk milk)
        {
            _context.Milks.Update(milk);
            await _context.SaveChangesAsync();
        }
    }
}
