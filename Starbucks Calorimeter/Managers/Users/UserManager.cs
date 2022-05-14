using Microsoft.EntityFrameworkCore;
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

        public async Task AddUser(User user)
        {
            context.Users.Add(user);

            await context.SaveChangesAsync();
        }

        public async Task DeleteUser(int id)
        {
            var user = await context.Users.FirstOrDefaultAsync(x => x.Id == id);

            context.Users.Remove(user);
            await context.SaveChangesAsync();
        }

        public async Task<List<User>> Filter(string? login)
        {
            var users = await GetAll();

            if (!string.IsNullOrEmpty(login))
            {
                users = users.Where(u => u.Login == login).ToList();
            }

            return users;
        }

        public async Task<List<User>> GetAll()
        {
            return await context.Users.AsNoTracking().ToListAsync();
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
