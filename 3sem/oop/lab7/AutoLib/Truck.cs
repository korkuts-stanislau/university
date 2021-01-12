namespace AutoLib
{
    public class Truck : Automobile
    {
        public int Load { get; }
        public Truck(string brand, int releaseDate, int milleage, string autoCode, int load) : base(brand, releaseDate, milleage, autoCode)
        {
            Load = load;
        }
        public override int[] GetCapacity()
        {
            return new int[] { Load, 0 };
        }
        public override string ToString()
        {
            return $"Грузовой, {Brand}, {ReleaseDate}, {Milleage}, {AutoCode}, {Load}";
        }
    }
}
