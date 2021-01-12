using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Azure.Cosmos.Table;

namespace CosmosTableSamples.Model
{
    class UkraineProm : TableEntity
    {
        public UkraineProm()
        {

        }
        public UkraineProm(string partition, string index)
        {
            PartitionKey = partition;
            RowKey = index;
        }
        public string PromType { get; set; }
        public string MeasureUnits { get; set; }
        public double Year1913 { get; set; }
        public double Year1928 { get; set; }
        public double Year1940 { get; set; }
        public double Year1959 { get; set; }

    }
}
