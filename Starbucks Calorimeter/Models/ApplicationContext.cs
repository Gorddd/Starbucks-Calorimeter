using Microsoft.EntityFrameworkCore;
using Starbucks_Calorimeter.Models.Entity;

namespace Starbucks_Calorimeter.Models
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Size> Sizes { get; set; }
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {

        }
        
    }
}
