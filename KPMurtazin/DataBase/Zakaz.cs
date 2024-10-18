using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KPMurtazin.DataBase
{
    public partial class Zakaz
    {
        public Zakaz()
        {
            Check = new HashSet<Check>();
        }
        public int ID_Zakaz { get; set; }
        public string Time_zakaz { get; set; }
        public int Day { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public virtual ICollection<Check> Check { get; set; }
    }
}
