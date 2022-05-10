using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Starbucks_Calorimeter.Models.Entity
{
    public class Drink
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public int SizeId { get; set; }
        public Size? Size { get; set; }

        public int EspressoId { get; set; }
        public Espresso? Espresso { get; set; }

        public int MilkId { get; set; }
        public Milk? Milk { get; set; }

        public int CreamId { get; set; }
        public Cream? Cream { get; set; }
        public double? Proteins { get; set; }
        public double? Fats { get; set; }
        public double? Carbohidrates { get; set; }
        public double? Coffeine { get; set; }
        public double? Calories { get; set; }

    }
}
