using Starbucks_Calorimeter.Models.Entity;

namespace Starbucks_Calorimeter.Managers.Drinks
{
    public class DrinkView
    {
        public Drink Drink { get; set; }

        public Dictionary<string, int> espShots { get; set; }
        public Dictionary<Espresso, int> addedEspShots { get; set; }

        public Dictionary<string, int> syrops { get; set; }
        public Dictionary<Syrop, int> addedSyrops { get; set; }

        public string MilkName { get; set; }
        public Milk addedMilk { get; set; }

        public string CreamName { get; set; }
        public Cream addedCream { get; set; }
    }
}
