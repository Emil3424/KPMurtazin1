using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KPMurtazin.DataBase
{
    public partial class Suppliers
    {
        public Suppliers()
        {
            Delivery = new HashSet<Delivery>();
        }
        public int ID_Supp { get; set; }
        public string Name { get; set; }
        public string Adress { get; set; }
        public int INN { get; set; }
        public int Contact_Tel{ get; set; }
        public string EMail { get; set; }
        public string Info { get; set; }
        public virtual ICollection<Delivery> Delivery { get; set; }
    }
}
