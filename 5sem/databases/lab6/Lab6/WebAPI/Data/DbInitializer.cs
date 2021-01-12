using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Data
{
    public class DbInitializer
    {
        int _refferenceTableSize;
        int _operationalTableSize;
        public DbInitializer(int refferenceTableSize = 100, int operationalTableSize = 1000)
        {
            _refferenceTableSize = refferenceTableSize;
            _operationalTableSize = operationalTableSize;
        }
        public async Task InitializeAsync(ComputerShopContext dbContext)
        {
            Random rand = new Random();
            if (!dbContext.Countries.Any())
            {
                for (int i = 0; i < _refferenceTableSize; i++)
                {
                    await dbContext.Countries.AddAsync(new Models.Country
                    {
                        Name = GetRandomString(50)
                    });
                }
            }
            await dbContext.SaveChangesAsync();

            if (!dbContext.Manufacturers.Any())
            {
                for (int i = 0; i < _refferenceTableSize; i++)
                {
                    await dbContext.Manufacturers.AddAsync(new Models.Manufacturer
                    {
                        Name = GetRandomString(50)
                    });
                }
            }
            await dbContext.SaveChangesAsync();

            if (!dbContext.ComponentTypes.Any())
            {
                for (int i = 0; i < _refferenceTableSize; i++)
                {
                    await dbContext.ComponentTypes.AddAsync(new Models.ComponentType
                    {
                        Name = GetRandomString(50),
                        Description = GetRandomString(150)
                    });
                }
            }
            await dbContext.SaveChangesAsync();

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
                    await dbContext.Components.AddAsync(new Models.Component
                    {
                        Model = GetRandomString(50),
                        ReleaseDate = GetRandomDate(new DateTime(2000, 1, 1), DateTime.Now),
                        Characteristics = GetRandomString(150),
                        WarrantyInMonths = rand.Next(6, 36),
                        Description = GetRandomString(150),
                        Price = rand.Next(200, 3000),
                        ComponentType = componentType,
                        ComponentTypeId = componentType.Id,
                        Manufacturer = manufacturer,
                        ManufacturerId = manufacturer.Id,
                        Country = country,
                        CountryId = country.Id
                    });
                }
            }
            await dbContext.SaveChangesAsync();
        }
        public string GetRandomString(int maxLength)
        {
            Random rand = new Random();
            int length = rand.Next(maxLength / 3, maxLength);
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var str = new char[length];
            int spaceRange = rand.Next(4, 7);
            for (int i = 0; i < length; i++)
            {
                if((i + 1) % spaceRange == 0)
                {
                    str[i] = ' ';
                    spaceRange = rand.Next(4, 7);
                    continue;
                }
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
