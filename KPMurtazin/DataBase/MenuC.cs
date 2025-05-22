using System.Collections.Generic;

namespace KPMurtazin.DataBase
{
    public partial class MenuC
    {
        public MenuC()
        {
            Purchase_Item = new HashSet<Purchase_items>();
            this.Bakery = new HashSet<Bakery>();
        }

        public int ID_Category { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Purchase_items> Purchase_Item { get; set; }
        public virtual ICollection<Bakery> Bakery { get; set; }
    }
}