using Microsoft.EntityFrameworkCore;
using Starbucks_Calorimeter.Models;
using Starbucks_Calorimeter.Models.Entity;

namespace Starbucks_Calorimeter.Managers.Creams
{
    public class CreamManager : ICreamManager
    {
        private ApplicationContext _context;

        public CreamManager(ApplicationContext context)
        {
            _context = context;
        }

        public async Task Add(Cream cream)
        {
            _context.Creams.Add(cream);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var cream = _context.Creams.FirstOrDefault(cr => cr.Id == id);

            _context.Creams.Remove(cream);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Cream>> Filter(string name)
        {
            var creams = await GetAll();

            if (!string.IsNullOrEmpty(name))
            {
                creams = creams.Where(s => s.Name == name).ToList();
            }

            return creams;
        }

        public async Task<Cream> Get(int id)
        {
            return _context.Creams.FirstOrDefault(cr => cr.Id == id);
        }

        public async Task<Drink> Get(string name)
        {
            return _context.Drinks.FirstOrDefault(d => d.Name == name);
        }

        public async Task<List<Cream>> GetAll()
        {
            return await _context.Creams.AsNoTracking().ToListAsync();
        }

        public async Task Update(Cream cream)
        {
            _context.Creams.Update(cream);
            await _context.SaveChangesAsync();
        }
    }
}
