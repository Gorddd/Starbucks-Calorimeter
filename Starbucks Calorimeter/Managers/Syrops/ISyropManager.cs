using Starbucks_Calorimeter.Models.Entity;

namespace Starbucks_Calorimeter.Managers.Syrops
{
    public interface ISyropManager
    {
        Task<List<Syrop>> GetAll();
        Task<Syrop> GetSyrop(int id);
        Task<Syrop> GetSyrop(string name);
        Task AddSyrop(Syrop syrop);
        Task DeleteSyrop(int id);
        Task UpdateSyrop(Syrop syrop);
        Task<List<Syrop>> Filter(string name);
    }
}
