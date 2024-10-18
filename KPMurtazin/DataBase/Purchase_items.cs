using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KPMurtazin.DataBase
{
    public partial class Purchase_items
    {
        public Purchase_items()
        {
            Check = new HashSet<Check>();
        }
        public int ID_item {  get; set; }
        public int ID_Category { get; set; }
        public string Nazvanie { get; set; }
        public double Cost { get; set; }
        public double Weight { get; set; }
        public double Calories { get; set; }
        public string Photo {  get; set; }
        public virtual MenuC MenuC { get; set; }
        public virtual ICollection<Check> Check { get; set;}
    }
}
