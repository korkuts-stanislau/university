using System;

namespace ZooLib
{
    public class PetShop
    {
        /// <summary>
        /// Класс питомец
        /// </summary>
        class Pet
        {
            public enum Type
            {
                кошка, собака, попугай, сова, ящерица, черепаха
            }
            public enum Skin
            {
                шерсть, оперение, чешуя
            }
            public enum House
            {
                домик, клетка, террариум, нет
            }
            public string PetName { get; set; }
            public Type PetType { get; set; }
            public Skin PetSkin { get; set; }
            public House PetHouse { get; set; }
            private Type FromStringToType(string item)
            {
                switch (item)
                {
                    case "кошка": return Type.кошка;
                    case "собака": return Type.собака;
                    case "попугай": return Type.попугай;
                    case "сова": return Type.сова;
                    case "ящерица": return Type.ящерица;
                    case "черепаха": return Type.черепаха;
                    default: throw new Exception("Неправильный ввод");
                }
            }
            private Skin FromStringToSkin(string item)
            {
                switch (item)
                {
                    case "шерсть": return Skin.шерсть;
                    case "оперение": return Skin.оперение;
                    case "чешуя": return Skin.чешуя;
                    default: throw new Exception("Неправильный ввод");
                }
            }
            private House FromStringToHouse(string item)
            {
                switch (item)
                {
                    case "домик": return House.домик;
                    case "клетка": return House.клетка;
                    case "террариум": return House.террариум;
                    case "нет": return House.нет;
                    default: throw new Exception("Неправильный ввод");
                }
            }
            public string[] StringInfo { get; set; }
            /// <summary>
            /// Конструктор класса Pet
            /// </summary>
            /// <param name="petInfo">Содержит запись типа "Имя", "Тип", "Кожный покров", "Жильё"</param>
            public Pet(string[] petInfo)
            {
                PetName = petInfo[0];
                PetType = FromStringToType(petInfo[1]);
                PetSkin = FromStringToSkin(petInfo[2]);
                PetHouse = FromStringToHouse(petInfo[3]);
                StringInfo = petInfo;
            }
        }
        // Код главного класса
        public PetShop(string[][] pets)
        {
            int count = 0;
            foreach (string[] petInfo in pets)
            {
                this.pets[count] = new Pet(petInfo);
                count += 1;
            }
            PetQuantity = count;
        }
        Pet[] pets = new Pet[500];
        int PetQuantity { get; set; }
        public void AddPet(string[] pet)
        {
            pets[PetQuantity] = new Pet(pet);
            PetQuantity += 1;
        }
        public void DeletePet(string petName)
        {
            int i = 0;
            for (; i < PetQuantity; i++)
            {
                if (pets[i].PetName.Equals(petName))
                {
                    break;
                }
            }
            for (; i < PetQuantity; i++)
            {
                pets[i] = pets[i + 1];
            }
            pets[PetQuantity - 1] = null;
            PetQuantity -= 1;
        }
        /// <summary>
        /// Метод заменяющий свойства питомца
        /// </summary>
        /// <param name="petInfo">Содержит запись типа "Имя", "Тип", "Кожный покров", "Жильё"</param>
        public void ChangePet(string[] petInfo)
        {
            int i = 0;
            for (; i < PetQuantity; i++)
            {
                if (pets[i].PetName.Equals(petInfo[0]))
                {
                    break;
                }
            }
            pets[i] = new Pet(petInfo);
        }
        public int FindPetsWithoutHome()
        {
            int count = 0;
            for(int i = 0; i < PetQuantity; i++)
            {
                if (pets[i].PetHouse.Equals(Pet.House.нет))
                    count += 1;
            }
            return count;
        }
        public int FindPetsBySkin(string skin)
        {
            int count = 0;
            for (int i = 0; i < PetQuantity; i++)
            {
                if (pets[i].StringInfo[2].Equals(skin))
                    count += 1;
            }
            return count;
        }
        public int FindPetsByType(string type)
        {
            int count = 0;
            for (int i = 0; i < PetQuantity; i++)
            {
                if (pets[i].StringInfo[1].Equals(type))
                    count += 1;
            }
            return count;
        }
        public string[] GetPetList()
        {
            string[] petList = new string[PetQuantity];
            for(int i = 0; i < PetQuantity; i++)
            {
                petList[i] = $"{pets[i].PetName}, {pets[i].PetType}, {pets[i].PetSkin}, {pets[i].PetHouse}";
            }
            return petList;
        }
    }
}
