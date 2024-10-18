using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KPMurtazin.DataBase
{
    public partial class Delivery
    {
        public Delivery()
        {
            Ingridients = new HashSet<Ingridients>();
        }
        public int ID_Deliv {  get; set; }
        public int ID_Sup {  get; set; }
        public string Date_Post { get; set; }
        public string Volume {  get; set; }
        public virtual Suppliers Suppliers { get; set; }
        public virtual ICollection<Ingridients> Ingridients { get; set; }
    }
}
