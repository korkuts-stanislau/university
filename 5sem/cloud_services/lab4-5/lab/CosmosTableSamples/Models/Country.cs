using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Azure.Cosmos.Table;

namespace CosmosTableSamples.Models
{
    public class Country : TableEntity
    {
        public string Name { get; set; }
        public Country()
        {

        }
        public Country(int id)
        {
            PartitionKey = "1";
            RowKey = id.ToString();
        }
    }
}
