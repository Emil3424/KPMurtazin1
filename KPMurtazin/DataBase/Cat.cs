using System.Collections.Generic;

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
        public int Age { get; set; }
        public string Date_Birth { get; set; }
        public string Breed { get; set; }
        public string MedIssues { get; set; }
        public virtual ICollection<Table> Table { get; set; }
    }
}