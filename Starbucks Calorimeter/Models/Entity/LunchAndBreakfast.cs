﻿namespace Starbucks_Calorimeter.Models.Entity
{
    public class LunchAndBreakfast
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Volume { get; set; }
        public double Proteins { get; set; }
        public double Fats { get; set; }
        public double Carbohidrates { get; set; }
        public double Calories { get; set; }
    }
}
