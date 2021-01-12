using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoLib
{
    public class Vehicle : Automobile
    {
        public int PassengersQuan { get; }
        public Vehicle(string brand, int releaseDate, int milleage, string autoCode, int passengersQuan) : base(brand, releaseDate, milleage, autoCode)
        {
            PassengersQuan = passengersQuan;
        }
        public override string ToString()
        {
            return $"Пассажирский, {Brand}, {ReleaseDate}, {Milleage}, {AutoCode}, {PassengersQuan}";
        }
        public override int[] GetCapacity()
        {
            return new int[] { 0, PassengersQuan };
        }
    }
}
