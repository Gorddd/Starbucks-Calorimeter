namespace Starbucks_Calorimeter.Models.Entity
{
    public class Drink
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public Size? Size { get; set; }
        public Espresso? Espresso { get; set; }
        public Milk? Milk { get; set; }
        public Cream? Cream { get; set; }
        public double? Proteins { get; set; }
        public double? Fats { get; set; }
        public double? Carbohidrates { get; set; }
        public double? Coffeine { get; set; }
        public double? Calories { get; set; }
    }
}
