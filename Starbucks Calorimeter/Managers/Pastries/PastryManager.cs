using Microsoft.EntityFrameworkCore;
using Starbucks_Calorimeter.Models;
using Starbucks_Calorimeter.Models.Entity;

namespace Starbucks_Calorimeter.Managers.Pastries
{
    public class PastryManager : IPastryManager
    {
        private ApplicationContext _context;

        public PastryManager(ApplicationContext context)
        {
            _context = context;
        }
        public async Task AddPastry(Pastry pastry)
        {
            _context.Pastries.Add(pastry);
            await _context.SaveChangesAsync();
        }

        public async Task DeletePastry(int id)
        {
            var pastry = await _context.Pastries.FirstOrDefaultAsync(p => p.Id == id);

            _context.Pastries.Remove(pastry);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Pastry>> Filter(string name)
        {
            var pastries = await GetAll();

            if (!string.IsNullOrEmpty(name))
            {
                pastries= pastries.Where(s => s.Name == name).ToList();
            }

            return pastries;
        }

        public async Task<List<Pastry>> GetAll()
        {
            return await _context.Pastries.AsNoTracking().ToListAsync();
        }

        public async Task<Pastry> GetPastry(int id)
        {
            return await _context.Pastries.FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<Pastry> GetPastry(string name)
        {
            return await _context.Pastries.FirstOrDefaultAsync(d => d.Name == name);
        }

        public async Task UpdatePastry(Pastry pastry)
        {
            _context.Pastries.Update(pastry);
            await _context.SaveChangesAsync();
        }
    }
}
