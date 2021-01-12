using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Azure.Cosmos.Table;

namespace CosmosTableSamples.Models
{
    public class Cinema : TableEntity
    {
        public string Name { get; set; }
        public int CityId { get; set; }
        public int TypeId { get; set; }
        public int Capacity { get; set; }

        public Cinema()
        {

        }

        public Cinema(int id)
        {
            PartitionKey = "1";
            RowKey = id.ToString();
        }
    }
}
