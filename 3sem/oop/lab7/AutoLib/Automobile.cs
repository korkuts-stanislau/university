using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoLib
{
    public enum AutomobileBrand
    {
        Nissan, Ford, Peugeot, Mazda, Toyota, Volkswagen, Renault, BMW, Audi, Mercedes
    }
    public class Automobile
    {
        public AutomobileBrand Brand { get; }
        public int ReleaseDate { get; }
        public int Milleage { get; set; }
        public string AutoCode { get; }
        public Automobile(string brand, int releaseDate, int milleage, string autoCode)
        {
            switch(brand)
            {
                case "BMW": Brand = AutomobileBrand.BMW; break;
                case "Audi": Brand = AutomobileBrand.Audi; break;
                case "Peugeot": Brand = AutomobileBrand.Peugeot; break;
                case "Mazda": Brand = AutomobileBrand.Mazda; break;
                case "Mercedes": Brand = AutomobileBrand.Mercedes; break;
                case "Toyota": Brand = AutomobileBrand.Toyota; break;
                case "Volkswagen": Brand = AutomobileBrand.Volkswagen; break;
                case "Nissan": Brand = AutomobileBrand.Nissan; break;
                case "Ford": Brand = AutomobileBrand.Ford; break;
                case "Renault": Brand = AutomobileBrand.Renault; break;
            }
            ReleaseDate = releaseDate;
            Milleage = milleage;
            AutoCode = autoCode;
        }
        /// <summary>
        /// Метод, возвращающий грузоподъёмность и пассажироемкость автомобиля
        /// </summary>
        /// <returns>Массив int {грузоподъемность, пассажироемкость}</returns>
        public virtual int[] GetCapacity()
        {
            return new int[] { 0, 0 };
        }
    }
}
