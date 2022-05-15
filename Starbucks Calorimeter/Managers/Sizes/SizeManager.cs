﻿using Microsoft.EntityFrameworkCore;
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

        public async Task AddSize(Size size)
        {
            _context.Sizes.Add(size);

            await _context.SaveChangesAsync();
        }

        public async Task DeleteSize(int id)
        {
            var size = await _context.Sizes.FirstOrDefaultAsync(x => x.Id == id);

            _context.Sizes.Remove(size);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Size>> Filter(string name)
        {
            var sizes = await GetAll();

            if (!string.IsNullOrEmpty(name))
            {
                sizes = sizes.Where(s => s.Name == name).ToList();
            }

            return sizes; 
        }

        public async Task<List<Size>> GetAll()
        {
            return await _context.Sizes.AsNoTracking().ToListAsync();
        }

        public Size GetSize(Size size)
        {
            return _context.Sizes.FirstOrDefault(s => s.Name == size.Name);
        }

        public async Task UpdateSize(Size size)
        {
            _context.Sizes.Update(size);
            await _context.SaveChangesAsync();
        }
    }
}
