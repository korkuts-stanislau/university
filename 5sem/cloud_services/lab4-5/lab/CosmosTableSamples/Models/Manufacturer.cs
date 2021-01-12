using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Azure.Cosmos.Table;

namespace CosmosTableSamples.Models
{
    public class Manufacturer : TableEntity
    {
        public string Name { get; set; }
        public Manufacturer()
        {

        }
        public Manufacturer(int id)
        {
            PartitionKey = "1";
            RowKey = id.ToString();
        }
    }
}
