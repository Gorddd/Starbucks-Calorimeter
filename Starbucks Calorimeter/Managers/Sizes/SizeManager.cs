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

        public async Task<List<Size>> GetAll()
        {
            return await _context.Sizes.ToListAsync();
        }
    }
}
