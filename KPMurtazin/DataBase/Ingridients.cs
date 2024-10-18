using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace KPMurtazin.DataBase
{
    public partial class Ingridients
    {
        public Ingridients()
        {
            Bakery = new HashSet<Bakery>();
        }
        public int Articul {  get; set; }
        public string Name { get; set; }
        public double KG { get; set; }
        public string Deliver {  get; set; }
        public string Box { get; set; }
        public int ID_Deliv { get; set; }
        public virtual Delivery Delivery { get; set; }
        public virtual ICollection<Bakery> Bakery { get; set; }
    }
}
