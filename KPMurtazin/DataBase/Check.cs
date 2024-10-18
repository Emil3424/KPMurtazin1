using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KPMurtazin.DataBase
{
    public partial class Check
    {
        public int ID_Check {  get; set; }
        public int ID_Table { get; set; }
        public int ID_Item { get; set; }
        public int ID_Sotrud { get; set; }
        public int ID_Zakaz { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }

        public double Discount { get; set; }

        public int ID_Allerg { get; set; }
        public virtual Table Table { get; set; }
        public virtual Purchase_items Purchase_Items { get; set; }
        public virtual Sotrudniki Sotrudniki { get; set; }
        public virtual Zakaz Zakaz { get; set; }
    }
}
