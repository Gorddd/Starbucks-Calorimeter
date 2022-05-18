using Microsoft.EntityFrameworkCore;
using Starbucks_Calorimeter.Models;
using Starbucks_Calorimeter.Models.Entity;

namespace Starbucks_Calorimeter.Managers.Drinks
{
    public class DrinkManager : IDrinkManager
    {
        private ApplicationContext _context;

        public DrinkManager(ApplicationContext context)
        {
            _context = context;
        } 

        public async Task AddDrink(Drink drink)
        {
            _context.Drinks.Add(drink);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteDrink(int id)
        {
            var drink = _context.Drinks.FirstOrDefault(d => d.Id == id);

            _context.Drinks.Remove(drink);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Drink>> Filter(string name)
        {
            var drinks = await GetAll();

            if (!string.IsNullOrEmpty(name))
            {
                drinks = drinks.Where(s => s.Name == name).ToList();
            }

            return drinks;
        }

        public async Task<List<Drink>> GetAll()
        {
            _context.Espressoes.Load();
            _context.Sizes.Load();
            _context.Creams.Load();
            _context.Milks.Load();

            return await _context.Drinks.ToListAsync();
        }

        public async Task<Drink> GetDrink(int id)
        {
            return _context.Drinks.FirstOrDefault(d => d.Id == id);
        }
        public async Task<Drink> GetDrink(string name)
        {
            _context.Espressoes.Load();
            _context.Sizes.Load();
            _context.Creams.Load();
            _context.Milks.Load();

            return _context.Drinks.FirstOrDefault(d => d.Name == name);
        }

        public async Task UpdateDrink(Drink drink)
        {
            _context.Drinks.Update(drink);
            await _context.SaveChangesAsync();
        }
    }
}
