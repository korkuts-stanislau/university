using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Azure.Cosmos.Table;

namespace CosmosTableSamples.Models
{
    public class Type : TableEntity
    {
        public string Name { get; set; }
        public Type()
        {

        }
        public Type(int id)
        {
            PartitionKey = "1";
            RowKey = id.ToString();
        }
    }
}
