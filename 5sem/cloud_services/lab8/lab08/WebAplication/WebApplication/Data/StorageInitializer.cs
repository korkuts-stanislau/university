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
            var Cities = await _so.CreateTableAsync("Cities");

            var types = await _so.CreateTableAsync("Types");

            var Cinemas = await _so.CreateTableAsync("Cinemas");

            for (int i = 0; i < 10; i++)
            {
                var type = new CosmosTableSamples.Models.Type(i) { Name = $"Type{i}" };
                await _eo.InsertOrMergeTypeAsync(types, type);
            }

            for (int i = 0; i < 10; i++)
            {
                var city = new CosmosTableSamples.Models.City(i) { Name = $"City{i}" };
                await _eo.InsertOrMergeCityAsync(Cities, city);
            }
            Random random = new Random();
            for (int i = 0; i < 10; i++)
            {
                var cinema = new CosmosTableSamples.Models.Cinema(i) { Name = $"Cinema{i}", Capacity = random.Next(100, 500), CityId = i, TypeId = i};
                await _eo.InsertOrMergeCinemaAsync(Cinemas, cinema);
            }
        }
    }
}
