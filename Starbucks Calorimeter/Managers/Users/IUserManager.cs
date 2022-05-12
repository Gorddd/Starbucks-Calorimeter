using Starbucks_Calorimeter.Models.Entity;

namespace Starbucks_Calorimeter.Managers.Users
{
    public interface IUserManager
    {
        User GetUser(string login, string password);
    }
}
