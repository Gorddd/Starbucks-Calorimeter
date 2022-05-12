using Starbucks_Calorimeter.Models.Entity;

namespace Starbucks_Calorimeter.Managers.Users
{
    public interface IUserManager
    {
        User GetUser(User user);
        Task UpdateUser(User user);
    }
}
