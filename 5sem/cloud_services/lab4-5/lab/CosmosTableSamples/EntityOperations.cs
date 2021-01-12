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
        public static async Task<Manufacturer> GetManufacturerAsync(CloudTable table, int id)
        {
            string partitionKey = "1";
            try
            {
                TableOperation retrieveOperation = TableOperation.Retrieve<Manufacturer>(partitionKey, id.ToString());
                TableResult result = await table.ExecuteAsync(retrieveOperation);
                Manufacturer manufacturer = result.Result as Manufacturer;
                return manufacturer;
            }
            catch (StorageException e)
            {
                Console.WriteLine(e.Message);
                Console.ReadLine();
                throw;
            }
        }

        public List<Manufacturer> GetManufacturers(CloudTable table)
        {
            TableQuery<Manufacturer> manufacturersQuery = new TableQuery<Manufacturer>();
            List<Manufacturer> manufacturers = new List<Manufacturer>();
            foreach(Manufacturer manufacturer in table.ExecuteQuery(manufacturersQuery))
            {
                manufacturers.Add(manufacturer);
            }
            return manufacturers;
        }

        public async Task<Manufacturer> InsertOrMergeManufacturerAsync(CloudTable table, Manufacturer manufacturer)
        {
            try
            {
                // Create the InsertOrReplace table operation
                TableOperation insertOrMergeOperation = TableOperation.InsertOrMerge(manufacturer);

                // Execute the operation.
                TableResult result = await table.ExecuteAsync(insertOrMergeOperation);
                Manufacturer insertedManufacturer = result.Result as Manufacturer;

                return insertedManufacturer;
            }
            catch (StorageException e)
            {
                Console.WriteLine(e.Message);
                Console.ReadLine();
                throw;
            }
        }

        private async Task<Manufacturer> DeleteManufacturerAsync(CloudTable table, Manufacturer manufacturer)
        {
            try
            {
                // Create the InsertOrReplace table operation
                TableOperation deleteOperation = TableOperation.Delete(manufacturer);
                // Execute the operation.
                TableResult result = await table.ExecuteAsync(deleteOperation);
                Manufacturer deletedManufacturer = result.Result as Manufacturer;

                return deletedManufacturer;
            }
            catch (StorageException e)
            {
                Console.WriteLine(e.Message);
                Console.ReadLine();
                throw;
            }
        }

        public async Task CascadeDeleteManufacturer(CloudTable phonesTable, CloudTable manufacturersTable, Manufacturer manufacturer)
        {
            try
            {
                var phones = GetPhones(phonesTable);
                foreach(Phone phone in phones)
                {
                    if(phone.ManufacturerId == int.Parse(manufacturer.RowKey))
                    {
                        await DeletePhoneAsync(phonesTable, phone);
                    }
                }
                await DeleteManufacturerAsync(manufacturersTable, manufacturer);
            }
            catch (StorageException e)
            {
                Console.WriteLine(e.Message);
                Console.ReadLine();
                throw;
            }
        }

        public static async Task<Country> GetCountryAsync(CloudTable table, int id)
        {
            string partitionKey = "1";
            try
            {
                TableOperation retrieveOperation = TableOperation.Retrieve<Country>(partitionKey, id.ToString());
                TableResult result = await table.ExecuteAsync(retrieveOperation);
                Country country = result.Result as Country;
                return country;
            }
            catch (StorageException e)
            {
                Console.WriteLine(e.Message);
                Console.ReadLine();
                throw;
            }
        }

        public List<Country> GetCountries(CloudTable table)
        {
            TableQuery<Country> countriesQuery = new TableQuery<Country>();
            List<Country> countries = new List<Country>();
            foreach (Country country in table.ExecuteQuery(countriesQuery))
            {
                countries.Add(country);
            }
            return countries;
        }

        public async Task<Country> InsertOrMergeCountryAsync(CloudTable table, Country country)
        {
            try
            {
                // Create the InsertOrReplace table operation
                TableOperation insertOrMergeOperation = TableOperation.InsertOrMerge(country);

                // Execute the operation.
                TableResult result = await table.ExecuteAsync(insertOrMergeOperation);
                Country insertedCountry = result.Result as Country;

                return insertedCountry;
            }
            catch (StorageException e)
            {
                Console.WriteLine(e.Message);
                Console.ReadLine();
                throw;
            }
        }

        private async Task<Country> DeleteCountryAsync(CloudTable table, Country country)
        {
            try
            {
                // Create the InsertOrReplace table operation
                TableOperation deleteOperation = TableOperation.Delete(country);
                // Execute the operation.
                TableResult result = await table.ExecuteAsync(deleteOperation);
                Country deletedCountry = result.Result as Country;

                return deletedCountry;
            }
            catch (StorageException e)
            {
                Console.WriteLine(e.Message);
                Console.ReadLine();
                throw;
            }
        }

        public async Task CascadeDeleteCountry(CloudTable phonesTable, CloudTable countriesTable, Country country)
        {
            try
            {
                var phones = GetPhones(phonesTable);
                foreach (Phone phone in phones)
                {
                    if (phone.CountryId == int.Parse(country.RowKey))
                    {
                        await DeletePhoneAsync(phonesTable, phone);
                    }
                }
                await DeleteCountryAsync(countriesTable, country);
            }
            catch (StorageException e)
            {
                Console.WriteLine(e.Message);
                Console.ReadLine();
                throw;
            }
        }

        public static async Task<Phone> GetPhoneAsync(CloudTable table, int id)
        {
            string partitionKey = "1";
            try
            {
                TableOperation retrieveOperation = TableOperation.Retrieve<Phone>(partitionKey, id.ToString());
                TableResult result = await table.ExecuteAsync(retrieveOperation);
                Phone phone = result.Result as Phone;
                return phone;
            }
            catch (StorageException e)
            {
                Console.WriteLine(e.Message);
                Console.ReadLine();
                throw;
            }
        }

        public List<Phone> GetPhones(CloudTable table)
        {
            TableQuery<Phone> phonesQuery = new TableQuery<Phone>();
            List<Phone> phones = new List<Phone>();
            foreach (Phone phone in table.ExecuteQuery(phonesQuery))
            {
                phones.Add(phone);
            }
            return phones;
        }

        public async Task<Phone> InsertOrMergePhoneAsync(CloudTable table, Phone phone)
        {
            try
            {
                // Create the InsertOrReplace table operation
                TableOperation insertOrMergeOperation = TableOperation.InsertOrMerge(phone);

                // Execute the operation.
                TableResult result = await table.ExecuteAsync(insertOrMergeOperation);
               Phone insertedPhone = result.Result as Phone;

                return insertedPhone;
            }
            catch (StorageException e)
            {
                Console.WriteLine(e.Message);
                Console.ReadLine();
                throw;
            }
        }

        public async Task<Phone> DeletePhoneAsync(CloudTable table, Phone phone)
        {
            try
            {
                // Create the InsertOrReplace table operation
                TableOperation deleteOperation = TableOperation.Delete(phone);
                // Execute the operation.
                TableResult result = await table.ExecuteAsync(deleteOperation);
                Phone deletedPhone = result.Result as Phone;

                return deletedPhone;
            }
            catch (StorageException e)
            {
                Console.WriteLine(e.Message);
                Console.ReadLine();
                throw;
            }
        }
    }
}
