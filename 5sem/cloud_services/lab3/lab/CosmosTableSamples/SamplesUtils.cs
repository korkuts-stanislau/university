using System;

namespace CosmosTableSamples
{
    using System.Threading.Tasks;
    using Microsoft.Azure.Cosmos.Table;
    using Model;

    class SamplesUtils
    {
        //  <QueryData>
        public static async Task<UkraineProm> RetrieveEntityUsingPointQueryAsync(CloudTable table, string partitionKey, string rowKey)
        {
            try
            {
                TableOperation retrieveOperation = TableOperation.Retrieve<UkraineProm>(partitionKey, rowKey);
                TableResult result = await table.ExecuteAsync(retrieveOperation);
                UkraineProm ukProm = result.Result as UkraineProm;
                return ukProm;
            }
            catch (StorageException e)
            {
                Console.WriteLine(e.Message);
                Console.ReadLine();
                throw;
            }
        }
        //  </QueryData>

        //  <InsertItem>
        public static async Task<UkraineProm> InsertOrMergeEntityAsync(CloudTable table, UkraineProm entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            try
            {
                // Create the InsertOrReplace table operation
                TableOperation insertOrMergeOperation = TableOperation.InsertOrMerge(entity);

                // Execute the operation.
                TableResult result = await table.ExecuteAsync(insertOrMergeOperation);
                UkraineProm insertedProm = result.Result as UkraineProm;

                return insertedProm;
            }
            catch (StorageException e)
            {
                Console.WriteLine(e.Message);
                Console.ReadLine();
                throw;
            }
        }

        /// <summary>
        /// Check if given connection string is for Azure Table storage or Azure CosmosDB Table.
        /// </summary>
        /// <returns>true if azure cosmosdb table</returns>
        public static bool IsAzureCosmosdbTable()
        {
            string storageConnectionString = AppSettings.LoadAppSettings().StorageConnectionString;
            return !String.IsNullOrEmpty(storageConnectionString) && (storageConnectionString.Contains("table.cosmosdb") || storageConnectionString.Contains("table.cosmos"));
        }
    }
}
