using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoLib
{
    public class Transport : Automobile
    {
        public int Load { get; }
        public int PassengersQuan { get; }
        public Transport(string brand, int releaseDate, int milleage, string autoCode, int load, int passengersQuan) : base(brand, releaseDate, milleage, autoCode)
        {
            Load = load;
            PassengersQuan = passengersQuan;
        }
        public override string ToString()
        {
            return $"Грузопассажирский, {Brand}, {ReleaseDate}, {Milleage}, {AutoCode}, {Load}, {PassengersQuan}";
        }
        public override int[] GetCapacity()
        {
            return new int[] { Load, PassengersQuan };
        }
    }
}
