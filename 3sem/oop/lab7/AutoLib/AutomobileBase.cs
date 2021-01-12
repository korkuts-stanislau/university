using System;
using System.Collections.Generic;
namespace AutoLib
{
    public class AutomobileBase
    {
        List<Automobile> automobiles = new List<Automobile>();
        public int BaseLength { get => this.automobiles.Count; }
        public Automobile this[int index]
        {
            get
            {
                return automobiles[index];
            }
            set
            {
                automobiles[index] = value;
            }
        }
        public AutomobileBase(string[] automobiles)
        {
            foreach(string auto in automobiles)
                this.automobiles.Add(AutomobileFromString(auto));
        }
        /// <summary>
        /// Метод, добавляющий автомобиль в массив автомобилей
        /// </summary>
        /// <param name="type">Тип автомобиля, может быть: transport, truck, vehicle</param>
        /// <param name="load">Необязательный параметр - грузоподъёмность</param>
        /// <param name="passengers">Необязательный параметр - пассажироемкость</param>
        public void AddAutomobile(string type, string brand, int releaseDate, int milleage, string autoCode, int load = 0, int passengers = 0)
        {
            foreach(Automobile auto in automobiles)
            {
                if (autoCode.Equals(auto.AutoCode))
                    throw new Exception("Машина с таким кодом уже есть");
            }
            switch (type)
            {
                case "transport":
                    automobiles.Add(new Transport(brand, releaseDate, milleage, autoCode, load, passengers));
                    return;
                case "truck":
                    automobiles.Add(new Truck(brand, releaseDate, milleage, autoCode, load));
                    return;
                case "vehicle":
                    automobiles.Add(new Vehicle(brand, releaseDate, milleage, autoCode, passengers));
                    return;
                default:
                    throw new Exception("Ошибка передачи параметра type");
            }
        }
        public void EditAutomobile(string autoCode, Automobile automobile)
        {
            int editIndex = 0;
            foreach (Automobile auto in automobiles)
            {
                if (autoCode.Equals(auto.AutoCode))
                    break;
                editIndex += 1;
            }
            automobiles[editIndex] = automobile;
        }
        public void DeleteAutomobile(string autoCode)
        {
            int deleteIndex = 0;
            foreach (Automobile auto in automobiles)
            {
                if (autoCode.Equals(auto.AutoCode))
                    break;
                deleteIndex += 1;
            }
            automobiles.RemoveAt(deleteIndex);
        }
        public double[] FindAverageLoadAndPassengers()
        {
            double load = 0;
            double passengers = 0;
            //0 - грузопассажирский, 1 - грузовой, 2 - пассажирский
            int[] typesQuan = new int[3];
            foreach (Automobile auto in automobiles)
            {
                if(auto is Transport)
                {
                    typesQuan[0] += 1;
                }
                else if (auto is Truck)
                {
                    typesQuan[1] += 1;
                }
                else if (auto is Vehicle)
                {
                    typesQuan[2] += 1;
                }
                else
                {
                    throw new Exception("Что-то пошло не так");
                }
                load += auto.GetCapacity()[0];
                passengers += auto.GetCapacity()[1];
            }
            return new double[] { load / (typesQuan[0] + typesQuan[1]), passengers / (typesQuan[0] + typesQuan[2]) };
        }
        private Type FromStingToType(string type)
        {
            switch(type)
            {
                case "automobile":
                    return typeof(Automobile);
                case "transport":
                    return typeof(Transport);
                case "truck":
                    return typeof(Truck);
                case "vehicle":
                    return typeof(Vehicle);
                default:
                    throw new Exception("Неверный тип");
            }
        }
        public double FindAverageMilleage(string type)
        {
            double milleage = 0;
            int count = 0;
            foreach(Automobile auto in automobiles)
            {
                if(auto.GetType() == FromStingToType(type))
                {
                    milleage += auto.Milleage;
                    count += 1;
                }
            }
            return milleage / count;
        }
        public Automobile AutomobileFromString(string autoString)
        {
            string[] data = autoString.Split(new string[] { ", " }, StringSplitOptions.None);
            switch(data[0])
            {
                case "Грузопассажирский":
                    return new Transport(data[1], Convert.ToInt32(data[2]), Convert.ToInt32(data[3]), data[4], Convert.ToInt32(data[5]), Convert.ToInt32(data[6]));
                case "Грузовой":
                    return new Truck(data[1], Convert.ToInt32(data[2]), Convert.ToInt32(data[3]), data[4], Convert.ToInt32(data[5]));
                case "Пассажирский":
                    return new Vehicle(data[1], Convert.ToInt32(data[2]), Convert.ToInt32(data[3]), data[4], Convert.ToInt32(data[5]));
                default:
                    throw new Exception("Неверная строка");
            }
        }
        public static string GetAutoCode(string data)
        {
            return data.Split(new string[] { ", " }, StringSplitOptions.None)[4];
        }
    }
}
