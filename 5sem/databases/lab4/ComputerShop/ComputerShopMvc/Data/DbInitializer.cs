using Microsoft.AspNetCore.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComputerShopMvc.Data
{
    public class DbInitializer
    {
        int _refferenceTableSize;
        int _operationalTableSize;
        public DbInitializer(int refferenceTableSize, int operationalTableSize)
        {
            _refferenceTableSize = refferenceTableSize;
            _operationalTableSize = operationalTableSize;
        }
        public void Initialize(ComputerShopContext dbContext)
        {
            Random rand = new Random();
            if (!dbContext.Countries.Any())
            {
                for(int i = 0; i < _refferenceTableSize; i++)
                {
                    dbContext.Countries.Add(new Models.Country 
                    { 
                        CountryName = GetRandomString(50) 
                    });
                }
            }
            dbContext.SaveChanges();
            if (!dbContext.Manufacturers.Any())
            {
                for (int i = 0; i < _refferenceTableSize; i++)
                {
                    dbContext.Manufacturers.Add(new Models.Manufacturer 
                    { 
                        ManufacturerName = GetRandomString(50) 
                    });
                }
            }
            dbContext.SaveChanges();
            if (!dbContext.ComponentTypes.Any())
            {
                for (int i = 0; i < _refferenceTableSize; i++)
                {
                    dbContext.ComponentTypes.Add(new Models.ComponentType 
                    { 
                        ComponentTypeName = GetRandomString(50),
                        ComponentTypeDescription = GetRandomString(150)
                    });
                }
            }
            dbContext.SaveChanges();
            if (!dbContext.Components.Any())
            {
                var componentTypes = dbContext.ComponentTypes.ToList();
                var manufacturers = dbContext.Manufacturers.ToList();
                var countries = dbContext.Countries.ToList();
                for (int i = 0; i < _operationalTableSize; i++)
                {
                    var componentType = componentTypes.ElementAt(rand.Next(dbContext.ComponentTypes.Count() - 1));
                    var manufacturer = manufacturers.ElementAt(rand.Next(dbContext.Manufacturers.Count() - 1));
                    var country = countries.ElementAt(rand.Next(dbContext.Countries.Count() - 1));
                    dbContext.Components.Add(new Models.Component
                    {
                        ComponentModel = GetRandomString(50),
                        ComponentReleaseDate = GetRandomDate(new DateTime(2000, 1, 1), DateTime.Now),
                        ComponentCharacteristics = GetRandomString(150),
                        ComponentWarrantyPeriodInMonths = rand.Next(6, 36),
                        ComponentDescription = GetRandomString(150),
                        ComponentPrice = rand.Next(200, 3000),
                        ComponentType = componentType,
                        ComponentTypeId = componentType.ComponentTypeId,
                        Manufacturer = manufacturer,
                        ManufacturerId = manufacturer.ManufacturerId,
                        Country = country,
                        CountryId = country.CountryId
                    });
                }
            }
            dbContext.SaveChanges();
        }
        public string GetRandomString(int maxLength)
        {
            Random rand = new Random();
            int length = rand.Next(maxLength / 3, maxLength);
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var str = new char[length];
            for (int i = 0; i < length; i++)
            {
                str[i] = chars[rand.Next(chars.Length)];
            }
            return new string(str);
        }
        public DateTime GetRandomDate(DateTime minDate, DateTime maxDate)
        {
            Random rand = new Random();
            int range = (maxDate - minDate).Days;
            return minDate.AddDays(rand.Next(range));
        }
    }
}
