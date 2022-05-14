using Microsoft.EntityFrameworkCore;
using Starbucks_Calorimeter.Models;
using Starbucks_Calorimeter.Models.Entity;

namespace Starbucks_Calorimeter.Managers.Sizes
{
    public class SizeManager : ISizeManager
    {
        private ApplicationContext _context;

        public SizeManager(ApplicationContext context)
        {
            _context = context;
        }

        public async Task Add(Size size)
        {
            _context.Sizes.Add(size);

            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var size = await _context.Sizes.FirstOrDefaultAsync(x => x.Id == id);

            _context.Sizes.Remove(size);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Size>> GetAll()
        {
            return await _context.Sizes.ToListAsync();
        }

        public async Task Update(Size size)
        {
            _context.Sizes.Update(size);
            await _context.SaveChangesAsync();
        }
    }
}
