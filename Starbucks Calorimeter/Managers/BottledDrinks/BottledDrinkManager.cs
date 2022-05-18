using Microsoft.EntityFrameworkCore;
using Starbucks_Calorimeter.Models;
using Starbucks_Calorimeter.Models.Entity;

namespace Starbucks_Calorimeter.Managers.BottledDrinks
{
    public class BottledDrinkManager : IBottledDrinkManager
    {
        private ApplicationContext _context;

        public BottledDrinkManager(ApplicationContext context)
        {
            _context = context;
        }

        public async Task Add(BottledDrink bottledDrink)
        {
            _context.BottledDrinks.Add(bottledDrink);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var bottledDrink = _context.BottledDrinks.FirstOrDefault(bd => bd.Id == id);

            _context.BottledDrinks.Remove(bottledDrink);
            await _context.SaveChangesAsync();
        }

        public async Task<List<BottledDrink>> Filter(string name)
        {
            var bottledDrinks = await GetAll();

            if (!string.IsNullOrEmpty(name))
            {
                bottledDrinks = bottledDrinks.Where(s => s.Name == name).ToList();
            }

            return bottledDrinks;
        }

        public async Task<BottledDrink> Get(int id)
        {
            return _context.BottledDrinks.FirstOrDefault(bd => bd.Id == id);
        }

        public async Task<BottledDrink> Get(string name)
        {
            return _context.BottledDrinks.FirstOrDefault(d => d.Name == name);
        }

        public async Task<List<BottledDrink>> GetAll()
        {
            return await _context.BottledDrinks.AsNoTracking().ToListAsync();
        }

        public async Task Update(BottledDrink bottledDrink)
        {
            _context.BottledDrinks.Update(bottledDrink);
            await _context.SaveChangesAsync();
        }
    }
}
