using System.IO;
using System;
using System.Text.RegularExpressions;

namespace ZooAppLib
{
    public enum Type
    {
        Cat,
        Dog,
        Hamster,
        Snake,
        Lizard,
        Turtle,
        Parrot,
        Owl,
        Crow
    }
    public enum Skin
    {
        Wool,//Шерсть
        Scale,//Чешуя
        Plumage//Оперение
    }
    public enum House
    {
        House,
        Cage,
        Terrarium,
        Aquarium,
        No
    }
    public class PetShop
    {
        public class Pet
        {
            string Name { get; set; }
            public Type Type { get; set; }
            public Skin Skin { get; set; }
            public House House { get; set; }
            public Pet()
            {
                //Do nothing
            }
            public Pet(string name, Type type, Skin skin, House house)
            {
                if (name == "")
                    throw new Exception("Empty field");
                Name = name;
                Type = type;
                Skin = skin;
                House = house;
            }
            public string ToString(bool isForFile)
            {
                if (isForFile)
                    return $"name<{Name}>   type<{EnumToString(Type)}>   skin<{EnumToString(Skin)}>   house<{EnumToString(House)}>";
                else
                    return $"Вид: {EnumToString(Type)}, Имя: {Name}, Покров: {EnumToString(Skin)}, Жилище: {EnumToString(House)}";
            }
        }
        
        Pet[] pets;
        string[] petsArray;
        public int PetQuantity{
            get
            {
                return this.pets.Length;
            }
        }
        public PetShop()
        {
            StringArrayInitialization(@"C:\korkuts_itp-21_oop\lab6-public\PetList.txt");
            PetsArrayInitialization();
        }
        public PetShop(Pet[] pets)
        {
            this.pets = pets;
        }
        void StringArrayInitialization(string path)
        {
            int array_length = 0;
            string line;
            using (StreamReader stream = new StreamReader(path)) //Инициализация массивов
            {
                while ((line = stream.ReadLine()) != null)
                {
                    if (!line.StartsWith("#"))
                        array_length += 1;
                }
                petsArray = new string[array_length];
                pets = new Pet[array_length];
            }
            using (StreamReader stream = new StreamReader(path)) //Инициализация элементов массивов
            {
                int ind = 0;
                while ((line = stream.ReadLine()) != null)
                {
                    if (!line.StartsWith("#"))
                    {
                        petsArray[ind] = line;
                        ind += 1;
                    }
                }
            }
        }
        void PetsArrayInitialization()
        {
            Regex rename = new Regex(@"name\<(?<value>\S+)\>");
            Regex retype = new Regex(@"type\<(?<value>\S+)\>");
            Regex reskin = new Regex(@"skin\<(?<value>\S+)\>");
            Regex rehouse = new Regex(@"house\<(?<value>\S+)\>");
            int ind = 0;
            string[] petInfo = new string[4];
            foreach(string pet in petsArray)
            {
                petInfo[0] = rename.Match(pet).Groups["value"].Value;
                petInfo[1] = retype.Match(pet).Groups["value"].Value;
                petInfo[2] = reskin.Match(pet).Groups["value"].Value;
                petInfo[3] = rehouse.Match(pet).Groups["value"].Value;
                pets[ind] = new Pet(petInfo[0], StringToType(petInfo[1]), StringToSkin(petInfo[2]), StringToHouse(petInfo[3]));
                ind += 1;
            }
        }
        public Pet this[int index]
        {
            get
            {
                return pets[index];
            }
            set
            {
                this.pets[index] = value;
            }
        }
        public static PetShop operator +(PetShop petShop, Pet pet)
        {
            Pet[] sumPets = new Pet[petShop.PetQuantity + 1];
            for(int i = 0; i < petShop.PetQuantity; i++)
            {
                sumPets[i] = petShop[i];
            }
            sumPets[petShop.PetQuantity] = pet;
            return new PetShop(sumPets);
        }
        public static string EnumToString(Type type)
        {
            switch(type)
            {
                case Type.Cat:
                    return "кошка";
                case Type.Dog:
                    return "собака";
                case Type.Hamster:
                    return "хомяк";
                case Type.Snake:
                    return "змея";
                case Type.Lizard:
                    return "ящерица";
                case Type.Turtle:
                    return "черепаха";
                case Type.Parrot:
                    return "попугай";
                case Type.Owl:
                    return "сова";
                case Type.Crow:
                    return "ворона";
                default:
                    throw new Exception("Шо за приколы");
            }
        }
        public static string EnumToString(Skin skin)
        {
            switch (skin)
            {
                case Skin.Wool:
                    return "шерсть";
                case Skin.Scale:
                    return "чешуя";
                case Skin.Plumage:
                    return "перья";
                default:
                    throw new Exception("Шо за приколы");
            }
        }
        public static string EnumToString(House house)
        {
            switch (house)
            {
                case House.House:
                    return "домик";
                case House.Cage:
                    return "клетка";
                case House.Terrarium:
                    return "террариум";
                case House.Aquarium:
                    return "аквариум";
                case House.No:
                    return "нет";
                default:
                    throw new Exception("Шо за приколы");
            }
        }
        public static Type StringToType(string type)
        {
            switch (type)
            {
                case "кошка":
                    return Type.Cat;
                case "собака":
                    return Type.Dog;
                case "хомяк":
                    return Type.Hamster;
                case "змея":
                    return Type.Snake;
                case "ящерица":
                    return Type.Lizard;
                case "черепаха":
                    return Type.Turtle;
                case "попугай":
                    return Type.Parrot;
                case "сова":
                    return Type.Owl;
                case "ворона":
                    return Type.Crow;
                default:
                    throw new Exception("Шо за приколы");
            }
        }
        public static House StringToHouse(string house)
        {
            switch (house)
            {
                case "домик":
                    return House.House;
                case "клетка":
                    return House.Cage;
                case "террариум":
                    return House.Terrarium;
                case "аквариум":
                    return House.Aquarium;
                case "нет":
                    return House.No;
                default:
                    throw new Exception("Шо за приколы");
            }
        }
        public static Skin StringToSkin(string skin)
        {
            switch (skin)
            {
                case "шерсть":
                    return Skin.Wool;
                case "чешуя":
                    return Skin.Scale;
                case "перья":
                    return Skin.Plumage;
                default:
                    throw new Exception("Шо за приколы");
            }
        }
    }
}
