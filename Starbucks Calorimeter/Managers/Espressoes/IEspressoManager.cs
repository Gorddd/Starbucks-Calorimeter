using Starbucks_Calorimeter.Models.Entity;

namespace Starbucks_Calorimeter.Managers.Espressoes
{
    public interface IEspressoManager
    {
        Task<List<Espresso>> GetAll(); //AsNoTracking
        Task<Espresso> Get(int id);
        Task<Espresso> Get(string name);
        Task Add(Espresso espresso);
        Task Update(Espresso espresso);
        Task Delete(int id);
        Task<List<Espresso>> Filter(string name);
    }
}
