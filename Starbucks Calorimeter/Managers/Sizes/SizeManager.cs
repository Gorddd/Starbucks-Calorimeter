using Microsoft.EntityFrameworkCore;
using Starbucks_Calorimeter.Models;
using Starbucks_Calorimeter.Models.Entity;

namespace Starbucks_Calorimeter.Managers;

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

    public async Task<Size> GetSize(int id)
    {
        return await _context.Sizes.FirstOrDefaultAsync(s => s.Id == id);
    }
    public async Task<Size> GetSize(string name)
    {
        return await _context.Sizes.FirstOrDefaultAsync(s => s.Name == name);
    }

    public async Task UpdateSize(Size size)
    {
        _context.Sizes.Update(size);
        await _context.SaveChangesAsync();
    }
}
