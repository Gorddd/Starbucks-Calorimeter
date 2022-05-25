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

        public int? EspressoId { get; set; }
        public Espresso? Espresso { get; set; }

        public int? MilkId { get; set; }
        public Milk? Milk { get; set; }

        public int? CreamId { get; set; }
        public Cream? Cream { get; set; }
        public double? Proteins { get; set; }
        public double? Fats { get; set; }
        public double? Carbohidrates { get; set; }
        public double? Coffeine { get; set; }
        public double? Calories { get; set; }

        public void AddNutritionalValue(Espresso espresso)
        {
            Proteins += espresso.Proteins;
            Fats += espresso.Fats;
            Carbohidrates += espresso.Carbohidrates;
            Coffeine += espresso.Coffeine;
            Calories += espresso.Calories;

            Proteins = Math.Round((double)Proteins, 2);
            Fats = Math.Round((double)Fats, 2);
            Carbohidrates = Math.Round((double)Carbohidrates, 2);
            Coffeine = Math.Round((double)Coffeine, 2);
            Calories = Math.Round((double)Calories, 2);
        }

        public void SubtractNutritionalValue(Espresso espresso)
        {
            Proteins -= espresso.Proteins;
            Fats -= espresso.Fats;
            Carbohidrates -= espresso.Carbohidrates;
            Coffeine -= espresso.Coffeine;
            Calories -= espresso.Calories;

            Proteins = Math.Round((double)Proteins, 2);
            Fats = Math.Round((double)Fats, 2);
            Carbohidrates = Math.Round((double)Carbohidrates, 2);
            Coffeine = Math.Round((double)Coffeine, 2);
            Calories = Math.Round((double)Calories, 2);
        }

        public void AddNutritionalValue(Syrop syrop)
        {
            Proteins += syrop.Proteins;
            Fats += syrop.Fats;
            Carbohidrates += syrop.Carbohidrates;
            Calories += syrop.Calories;

            Proteins = Math.Round((double)Proteins, 2);
            Fats = Math.Round((double)Fats, 2);
            Carbohidrates = Math.Round((double)Carbohidrates, 2);
            Coffeine = Math.Round((double)Coffeine, 2);
        }

        public void SubtractNutritionalValue(Syrop syrop)
        {
            Proteins -= syrop.Proteins;
            Fats -= syrop.Fats;
            Carbohidrates -= syrop.Carbohidrates;
            Calories -= syrop.Calories;

            Proteins = Math.Round((double)Proteins, 2);
            Fats = Math.Round((double)Fats, 2);
            Carbohidrates = Math.Round((double)Carbohidrates, 2);
            Coffeine = Math.Round((double)Coffeine, 2);
        }

        public void AddNutritionalValue(Milk milk)
        {
            Proteins += milk.Proteins;
            Fats += milk.Fats;
            Carbohidrates += milk.Carbohidrates;
            Calories += milk.Calories;

            Proteins = Math.Round((double)Proteins, 2);
            Fats = Math.Round((double)Fats, 2);
            Carbohidrates = Math.Round((double)Carbohidrates, 2);
            Coffeine = Math.Round((double)Coffeine, 2);
        }

        public void SubtractNutritionalValue(Milk milk)
        {
            Proteins -= milk.Proteins;
            Fats -= milk.Fats;
            Carbohidrates -= milk.Carbohidrates;
            Calories -= milk.Calories;

            Proteins = Math.Round((double)Proteins, 2);
            Fats = Math.Round((double)Fats, 2);
            Carbohidrates = Math.Round((double)Carbohidrates, 2);
            Coffeine = Math.Round((double)Coffeine, 2);
        }

        public void AddNutritionalValue(Cream cream)
        {
            Proteins += cream.Proteins;
            Fats += cream.Fats;
            Carbohidrates += cream.Carbohidrates;
            Calories += cream.Calories;

            Proteins = Math.Round((double)Proteins, 2);
            Fats = Math.Round((double)Fats, 2);
            Carbohidrates = Math.Round((double)Carbohidrates, 2);
            Coffeine = Math.Round((double)Coffeine, 2);
        }
    }
}
