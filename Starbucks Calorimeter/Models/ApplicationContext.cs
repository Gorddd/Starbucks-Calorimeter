using Microsoft.EntityFrameworkCore;
using Starbucks_Calorimeter.Models.Entity;

namespace Starbucks_Calorimeter.Models
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Size> Sizes { get; set; }
        public DbSet<Drink> Drinks { get; set; }
        public DbSet<BottledDrink> BottledDrinks { get; set; }
        public DbSet<Cream> Creams { get; set; }
        public DbSet<Dessert> Desserts { get; set; }
        public DbSet<Espresso> Espressoes { get; set; }
        public DbSet<FoodInPackage> FoodInPackages { get; set; }
        public DbSet<LunchAndBreakfast> LunchAndBreakfasts { get; set; }
        public DbSet<Milk> Milks { get; set; }
        public DbSet<Pastry> Pastry { get; set; }
        public DbSet<Syrop> Syrops { get; set; }


        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {

        }
        
    }
}
