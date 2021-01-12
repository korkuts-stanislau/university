using CosmosTableSamples.Models;
using Microsoft.Azure.Cosmos.Table;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CosmosTableSamples
{
    public class StorageOperations
    {
        public async Task<CloudTable> CreateTableAsync(string tableName)
        {
            return await Common.CreateTableAsync(tableName);
        }
    }
}
