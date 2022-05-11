using Starbucks_Calorimeter.Models;
using Starbucks_Calorimeter.Models.Entity;

namespace Starbucks_Calorimeter.Managers.Users
{
    public class UserManager : IUserManager
    {
        ApplicationContext context;

        public UserManager(ApplicationContext context)
        {
            this.context = context;
        }

        public User GetUser(string login, string password)
        {
            return context.Users.FirstOrDefault(u => u.Login == login && u.Password == password);
        }
    }
}
