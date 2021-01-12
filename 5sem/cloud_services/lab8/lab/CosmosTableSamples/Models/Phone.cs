using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Azure.Cosmos.Table;

namespace CosmosTableSamples.Models
{
    public class Phone : TableEntity
    {
        public int ManufacturerId { get; set; }
        public int CountryId { get; set; }
        public string ModelName { get; set; }
        public int Price { get; set; }
        public Phone()
        {

        }
        public Phone(int id)
        {
            PartitionKey = "1";
            RowKey = id.ToString();
        }
    }
}
