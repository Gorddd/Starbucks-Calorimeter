using Microsoft.EntityFrameworkCore;
using Starbucks_Calorimeter.Models;
using Starbucks_Calorimeter.Models.Entity;

namespace Starbucks_Calorimeter.Managers;

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

    public async Task<Syrop> GetSyrop(int id)
    {
        return await _context.Syrops.FirstOrDefaultAsync(s => s.Id == id);
    }
    public async Task<Syrop> GetSyrop(string name)
    {
        return await _context.Syrops.FirstOrDefaultAsync(s => s.Name == name);
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
