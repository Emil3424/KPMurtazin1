namespace KPMurtazin.DataBase
{
    public partial class Bakery
    {
        public int ID_Prod { get; set; }
        public int Articul { get; set; }
        public virtual Ingridients Ingridients { get; set; }
        public virtual MenuC MenuC { get; set; }
    }
}