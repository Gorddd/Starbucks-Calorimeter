using Microsoft.EntityFrameworkCore;
using Starbucks_Calorimeter.Models;
using Starbucks_Calorimeter.Models.Entity;

namespace Starbucks_Calorimeter.Managers.Desserts
{
    public class DessertManager : IDessertManager
    {
        private ApplicationContext _context;

        public DessertManager(ApplicationContext context)
        {
            _context = context;
        }

        public async Task Add(Dessert dessert)
        {
            _context.Desserts.Add(dessert);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var dessert = _context.Desserts.FirstOrDefault(des => des.Id == id);

            _context.Desserts.Remove(dessert);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Dessert>> Filter(string name)
        {
            var desserts = await GetAll();

            if (!string.IsNullOrEmpty(name))
            {
                desserts = desserts.Where(s => s.Name == name).ToList();
            }

            return desserts;
        }

        public async Task<Dessert> Get(int id)
        {
            return _context.Desserts.FirstOrDefault(des => des.Id == id);
        }

        public async Task<Dessert> Get(string name)
        {
            return _context.Desserts.FirstOrDefault(d => d.Name == name);
        }

        public async Task<List<Dessert>> GetAll()
        {
            return await _context.Desserts.AsNoTracking().ToListAsync();
        }

        public async Task Update(Dessert dessert)
        {
            _context.Desserts.Update(dessert);
            await _context.SaveChangesAsync();
        }
    }
}
