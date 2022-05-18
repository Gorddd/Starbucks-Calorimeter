using Starbucks_Calorimeter.Models.Entity;

namespace Starbucks_Calorimeter.Managers.Creams
{
    public interface ICreamManager
    {
        Task<List<Cream>> GetAll(); //AsNoTracking
        Task<Cream> Get(int id);
        Task<Cream> Get(string name);
        Task Add(Cream cream);
        Task Update(Cream cream);
        Task Delete(int id);
        Task<List<Cream>> Filter(string name);
    }
}
