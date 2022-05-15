using Microsoft.EntityFrameworkCore;
using Starbucks_Calorimeter.Models;
using Starbucks_Calorimeter.Models.Entity;

namespace Starbucks_Calorimeter.Managers.Espressoes
{

    public class EspressoManager : IEspressoManager
    {
        private ApplicationContext _context;

        public EspressoManager(ApplicationContext context)
        {
            _context = context;
        }

        public async Task Add(Espresso espresso)
        {
            _context.Espressoes.Add(espresso);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var espresso = _context.Espressoes.FirstOrDefault(es => es.Id == id);
            
            _context.Espressoes.Remove(espresso);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Espresso>> Filter(string name)
        {
            var espressos = await GetAll();

            if (!string.IsNullOrEmpty(name))
            {
                espressos = espressos.Where(s => s.Name == name).ToList();
            }

            return espressos;
        }

        public async Task<Espresso> Get(int id)
        {
            return _context.Espressoes.FirstOrDefault(es => es.Id == id);
        }

        public async Task<List<Espresso>> GetAll()
        {
            return await _context.Espressoes.AsNoTracking().ToListAsync();
        }

        public async Task Update(Espresso espresso)
        {
            _context.Espressoes.Update(espresso);
            await _context.SaveChangesAsync();
        }
    }
}
