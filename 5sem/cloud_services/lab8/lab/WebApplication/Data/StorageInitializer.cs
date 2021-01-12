using System;
using CosmosTableSamples;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Data
{
    public class StorageInitializer
    {
        StorageOperations _so;
        EntityOperations _eo;
        public StorageInitializer()
        {
            _so = new StorageOperations();
            _eo = new EntityOperations();
        }
        public async Task Initialize()
        {
            var manufacturers = await _so.CreateTableAsync("manufacturers");

            var countries = await _so.CreateTableAsync("countries");

            var phones = await _so.CreateTableAsync("phones");

            for (int i = 0; i < 10; i++)
            {
                var country = new CosmosTableSamples.Models.Country(i) { Name = $"Country{i}" };
                await _eo.InsertOrMergeCountryAsync(countries, country);
            }

            for (int i = 0; i < 10; i++)
            {
                var manufacturer = new CosmosTableSamples.Models.Manufacturer(i) { Name = $"Manufacturer{i}" };
                await _eo.InsertOrMergeManufacturerAsync(manufacturers, manufacturer);
            }
            Random random = new Random();
            for (int i = 0; i < 10; i++)
            {
                var phone = new CosmosTableSamples.Models.Phone(i) { ModelName = $"Phone{i}", Price = random.Next(1000, 5000), ManufacturerId = i, CountryId = i};
                await _eo.InsertOrMergePhoneAsync(phones, phone);
            }
        }
    }
}
