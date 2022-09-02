using Starbucks_Calorimeter.Models.Entity;

namespace Starbucks_Calorimeter.Managers;

public interface IUserManager
{
    Task<List<User>> GetAll();
    User GetUser(User user);
    Task AddUser(User user);
    Task DeleteUser(int id);
    Task UpdateUser(User user);
    Task<List<User>> Filter(string login);
}
