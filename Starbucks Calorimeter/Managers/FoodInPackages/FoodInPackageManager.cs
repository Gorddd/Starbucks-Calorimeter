using Microsoft.EntityFrameworkCore;
using Starbucks_Calorimeter.Models;
using Starbucks_Calorimeter.Models.Entity;

namespace Starbucks_Calorimeter.Managers;

public class FoodInPackageManager : IFoodInPackageManager
{
    private ApplicationContext _context;
    public FoodInPackageManager(ApplicationContext context)
    {
        _context = context;
    }
    public async Task Add(FoodInPackage foodInPackage)
    {
        _context.FoodInPackages.Add(foodInPackage);
        await _context.SaveChangesAsync();
    }

    public async Task Delete(int id)
    {
        var foodInPackage = _context.FoodInPackages.FirstOrDefault(f => f.Id == id);

        _context.FoodInPackages.Remove(foodInPackage);
        await _context.SaveChangesAsync();
    }

    public async Task<List<FoodInPackage>> Filter(string name)
    {
        var foodInPackages = await GetAll();

        if (!string.IsNullOrEmpty(name))
        {
            foodInPackages = foodInPackages.Where(s => s.Name == name).ToList();
        }

        return foodInPackages;
    }

    public async Task<FoodInPackage> Get(int id)
    {
        return await _context.FoodInPackages.FirstOrDefaultAsync(f => f.Id == id);
    }

    public async Task<FoodInPackage> Get(string name)
    {
        return await _context.FoodInPackages.FirstOrDefaultAsync(d => d.Name == name);
    }

    public async Task<List<FoodInPackage>> GetAll()
    {
        return await _context.FoodInPackages.AsNoTracking().ToListAsync();
    }

    public async Task Update(FoodInPackage foodInPackage)
    {
        _context.FoodInPackages.Update(foodInPackage);
        await _context.SaveChangesAsync();
    }
}
