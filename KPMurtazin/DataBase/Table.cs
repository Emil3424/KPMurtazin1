using System.Collections.Generic;

namespace KPMurtazin.DataBase
{
    public partial class Table
    {
        public Table()
        {
            Check = new HashSet<Check>();
        }

        public int ID_Table { get; set; }
        public string Name { get; set; }
        public int ID_Cat { get; set; }
        public virtual Cat Cat { get; set; }
        public virtual ICollection<Check> Check { get; set; }
    }
}