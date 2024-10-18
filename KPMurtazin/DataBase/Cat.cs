using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KPMurtazin.DataBase
{
    public partial class Cat
    {
        public Cat()
        {
            Table = new HashSet<Table>();
        }
        public int ID_Cat { get; set; }
        public string Cat_Name { get; set; }
        public int Age {  get; set; }
        public string Date_Birth {  get; set; }
        public string Breed {  get; set; }
        public virtual ICollection<Table> Table { get; set;}
    }
}
