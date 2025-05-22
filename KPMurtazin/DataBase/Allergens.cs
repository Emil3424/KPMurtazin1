using System.Collections.Generic;

namespace KPMurtazin.DataBase
{
    public partial class Allergens
    {
        public Allergens()
        {
            Check = new HashSet<Check>();
        }

        public int ID_allerg { get; set; }
        public string Allergen { get; set; }
        public double Protein { get; set; }
        public double Fats { get; set; }
        public double CarboHydrates { get; set; }
        public virtual ICollection<Check> Check { get; set; }
    }
}