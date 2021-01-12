using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Azure.Cosmos.Table;

namespace CosmosTableSamples.Models
{
    public class City : TableEntity
    {
        public string Name { get; set; }
        public City()
        {

        }
        public City(int id)
        {
            PartitionKey = "1";
            RowKey = id.ToString();
        }
    }
}
