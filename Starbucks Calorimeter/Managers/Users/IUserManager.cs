using Starbucks_Calorimeter.Models.Entity;

namespace Starbucks_Calorimeter.Managers.Users
{
    public interface IUserManager
    {
        Task<List<User>> GetAll();
        User GetUser(User user);
        Task UpdateUser(User user);
    }
}
