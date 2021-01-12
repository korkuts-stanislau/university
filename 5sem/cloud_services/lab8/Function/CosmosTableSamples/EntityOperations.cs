using CosmosTableSamples.Models;
using Microsoft.Azure.Cosmos.Table;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CosmosTableSamples
{
    public class EntityOperations
    {
        #region City
        public static async Task<City> GetCityAsync(CloudTable table, int id)
        {
            string partitionKey = "1";
            try
            {
                TableOperation retrieveOperation = TableOperation.Retrieve<City>(partitionKey, id.ToString());
                TableResult result = await table.ExecuteAsync(retrieveOperation);
                City city = result.Result as City;
                return city;
            }
            catch (StorageException e)
            {
                Console.WriteLine(e.Message);
                Console.ReadLine();
                throw;
            }
        }

        public List<City> GetCities(CloudTable table)
        {
            TableQuery<City> CitiesQuery = new TableQuery<City>();
            List<City> Cities = new List<City>();
            foreach(City city in table.ExecuteQuery(CitiesQuery))
            {
                Cities.Add(city);
            }
            return Cities;
        }

        public async Task<City> InsertOrMergeCityAsync(CloudTable table, City city)
        {
            try
            {
                // Create the InsertOrReplace table operation
                TableOperation insertOrMergeOperation = TableOperation.InsertOrMerge(city);

                // Execute the operation.
                TableResult result = await table.ExecuteAsync(insertOrMergeOperation);
                City insertedCity = result.Result as City;

                return insertedCity;
            }
            catch (StorageException e)
            {
                Console.WriteLine(e.Message);
                Console.ReadLine();
                throw;
            }
        }

        private async Task<City> DeleteCityAsync(CloudTable table, City city)
        {
            try
            {
                // Create the InsertOrReplace table operation
                TableOperation deleteOperation = TableOperation.Delete(city);
                // Execute the operation.
                TableResult result = await table.ExecuteAsync(deleteOperation);
                City deletedCity = result.Result as City;

                return deletedCity;
            }
            catch (StorageException e)
            {
                Console.WriteLine(e.Message);
                Console.ReadLine();
                throw;
            }
        }

        public async Task CascadeDeleteCity(CloudTable CinemasTable, CloudTable CitiesTable, City city)
        {
            try
            {
                var Cinemas = GetCinemas(CinemasTable);
                foreach(Cinema Cinema in Cinemas)
                {
                    if(Cinema.CityId == int.Parse(city.RowKey))
                    {
                        await DeleteCinemaAsync(CinemasTable, Cinema);
                    }
                }
                await DeleteCityAsync(CitiesTable, city);
            }
            catch (StorageException e)
            {
                Console.WriteLine(e.Message);
                Console.ReadLine();
                throw;
            }
        }
        #endregion

        #region Type
        public static async Task<Models.Type> GetTypeAsync(CloudTable table, int id)
        {
            string partitionKey = "1";
            try
            {
                TableOperation retrieveOperation = TableOperation.Retrieve<Models.Type>(partitionKey, id.ToString());
                TableResult result = await table.ExecuteAsync(retrieveOperation);
                Models.Type type = result.Result as Models.Type;
                return type;
            }
            catch (StorageException e)
            {
                Console.WriteLine(e.Message);
                Console.ReadLine();
                throw;
            }
        }

        public List<Models.Type> GetTypes(CloudTable table)
        {
            TableQuery<Models.Type> typesQuery = new TableQuery<Models.Type>();
            List<Models.Type> types = new List<Models.Type>();
            foreach (Models.Type type in table.ExecuteQuery(typesQuery))
            {
                types.Add(type);
            }
            return types;
        }

        public async Task<Models.Type> InsertOrMergeTypeAsync(CloudTable table, Models.Type type)
        {
            try
            {
                // Create the InsertOrReplace table operation
                TableOperation insertOrMergeOperation = TableOperation.InsertOrMerge(type);

                // Execute the operation.
                TableResult result = await table.ExecuteAsync(insertOrMergeOperation);
                Models.Type insertedType = result.Result as Models.Type;

                return insertedType;
            }
            catch (StorageException e)
            {
                Console.WriteLine(e.Message);
                Console.ReadLine();
                throw;
            }
        }

        private async Task<Models.Type> DeleteTypeAsync(CloudTable table, Models.Type type)
        {
            try
            {
                // Create the InsertOrReplace table operation
                TableOperation deleteOperation = TableOperation.Delete(type);
                // Execute the operation.
                TableResult result = await table.ExecuteAsync(deleteOperation);
                Models.Type deletedType = result.Result as Models.Type;

                return deletedType;
            }
            catch (StorageException e)
            {
                Console.WriteLine(e.Message);
                Console.ReadLine();
                throw;
            }
        }

        public async Task CascadeDeleteType(CloudTable CinemasTable, CloudTable typesTable, Models.Type type)
        {
            try
            {
                var Cinemas = GetCinemas(CinemasTable);
                foreach (Cinema Cinema in Cinemas)
                {
                    if (Cinema.TypeId == int.Parse(type.RowKey))
                    {
                        await DeleteCinemaAsync(CinemasTable, Cinema);
                    }
                }
                await DeleteTypeAsync(typesTable, type);
            }
            catch (StorageException e)
            {
                Console.WriteLine(e.Message);
                Console.ReadLine();
                throw;
            }
        }
        #endregion

        #region City
        public static async Task<Cinema> GetCinemaAsync(CloudTable table, int id)
        {
            string partitionKey = "1";
            try
            {
                TableOperation retrieveOperation = TableOperation.Retrieve<Cinema>(partitionKey, id.ToString());
                TableResult result = await table.ExecuteAsync(retrieveOperation);
                Cinema Cinema = result.Result as Cinema;
                return Cinema;
            }
            catch (StorageException e)
            {
                Console.WriteLine(e.Message);
                Console.ReadLine();
                throw;
            }
        }

        public List<Cinema> GetCinemas(CloudTable table)
        {
            TableQuery<Cinema> CinemasQuery = new TableQuery<Cinema>();
            List<Cinema> Cinemas = new List<Cinema>();
            foreach (Cinema Cinema in table.ExecuteQuery(CinemasQuery))
            {
                Cinemas.Add(Cinema);
            }
            return Cinemas;
        }

        public async Task<Cinema> InsertOrMergeCinemaAsync(CloudTable table, Cinema cinema)
        {
            try
            {
                // Create the InsertOrReplace table operation
                TableOperation insertOrMergeOperation = TableOperation.InsertOrMerge(cinema);

                // Execute the operation.
                TableResult result = await table.ExecuteAsync(insertOrMergeOperation);
               Cinema insertedCinema = result.Result as Cinema;

                return insertedCinema;
            }
            catch (StorageException e)
            {
                Console.WriteLine(e.Message);
                Console.ReadLine();
                throw;
            }
        }

        public async Task<Cinema> DeleteCinemaAsync(CloudTable table, Cinema cinema)
        {
            try
            {
                // Create the InsertOrReplace table operation
                TableOperation deleteOperation = TableOperation.Delete(cinema);
                // Execute the operation.
                TableResult result = await table.ExecuteAsync(deleteOperation);
                Cinema deletedCinema = result.Result as Cinema;

                return deletedCinema;
            }
            catch (StorageException e)
            {
                Console.WriteLine(e.Message);
                Console.ReadLine();
                throw;
            }
        }
        #endregion
    }
}
