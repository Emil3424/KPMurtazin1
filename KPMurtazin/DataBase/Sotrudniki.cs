using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KPMurtazin.DataBase
{
    public partial class Sotrudniki
    {
        public Sotrudniki()
        {
            Check = new HashSet<Check>();
        }
        public int ID_Sotr { get; set; }
        public string FIO {  get; set; }
        public string Gender {  get; set; }
        public string Date_Birth {  get; set; }
        public string Adress { get; set; }
        public string Job { get; set; }
        public string Schedule { get; set; }
        public double Salary{ get; set; }
        public string Education{ get; set; }
        public int Telefon { get; set; }
        public virtual ICollection<Check> Check { get; set; }
    }
}
