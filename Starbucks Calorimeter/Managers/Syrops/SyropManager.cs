using Microsoft.EntityFrameworkCore;
using Starbucks_Calorimeter.Models;
using Starbucks_Calorimeter.Models.Entity;

namespace Starbucks_Calorimeter.Managers.Syrops
{
    public class SyropManager : ISyropManager
    {
        private ApplicationContext _context;

        public SyropManager(ApplicationContext context)
        {
            _context = context;
        }
        
        public async Task AddSyrop(Syrop syrop)
        {
            _context.Syrops.Add(syrop);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteSyrop(int id)
        {
            var syrop = _context.Syrops.FirstOrDefault(sy => sy.Id == id);
            
            _context.Syrops.Remove(syrop);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Syrop>> Filter(string name)
        {
            var syrops = await GetAll();

            if (!string.IsNullOrEmpty(name))
            {
                syrops = syrops.Where(s => s.Name == name).ToList();
            }

            return syrops;
        }

        public Syrop GetSyrop(Syrop syrop)
        {
            return _context.Syrops.FirstOrDefault(s => s.Name == syrop.Name);
        }

        public async Task<List<Syrop>> GetAll()
        {
            return await _context.Syrops.AsNoTracking().ToListAsync();
        }

        public async Task UpdateSyrop(Syrop syrop)
        {
            _context.Syrops.Update(syrop);
            await _context.SaveChangesAsync();
        }
    }
}
