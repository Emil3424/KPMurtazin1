using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KPMurtazin.DataBase
{
    public partial class MenuC
    {
        public MenuC()
        {
            Purchase_Item = new HashSet<Purchase_items>();
            this.Bakery = new HashSet<Bakery>();
        }
        public int ID_Category {  get; set; }
        public string Category { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public double Weight { get; set; }
        public double Calory { get; set; }
        public virtual ICollection<Purchase_items> Purchase_Item { get; set; }
        public virtual ICollection<Bakery> Bakery { get; set; }
    }
}
