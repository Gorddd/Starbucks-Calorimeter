using Starbucks_Calorimeter.Models.Entity;

namespace Starbucks_Calorimeter.Managers.Pastries
{
    public interface IPastryManager
    {
        Task<List<Pastry>> GetAll();
        Task<Pastry> GetPastry(int id);
        Pastry GetPastry(string name);
        Task AddPastry(Pastry pastry);
        Task DeletePastry(int id);
        Task UpdatePastry(Pastry pastry);
        Task<List<Pastry>> Filter(string name);
    }
}
