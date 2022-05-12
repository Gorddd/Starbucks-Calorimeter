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

        public User GetUser(User user)
        {
            return context.Users.FirstOrDefault(u => u.Login == user.Login && u.Password == user.Password);
        }

        public async Task UpdateUser(User user)
        {
            context.Users.Update(user);
            await context.SaveChangesAsync();
        }
    }
}
