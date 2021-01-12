using System;

namespace CosmosTableSamples
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Microsoft.Azure.Cosmos.Table;
    using Model;

    class BasicSamples
    {
        public async Task RunSamples()
        {
            string tableName = "UkraineProm";
            // Create or reference an existing table
            CloudTable table = await Common.CreateTableAsync(tableName);
            try
            {
                // Demonstrate basic CRUD functionality 
                await BasicDataOperationsAsync(table);
            }
            finally
            {
                // Delete the table
                // await table.DeleteIfExistsAsync();
            }
        }

        private static async Task BasicDataOperationsAsync(CloudTable table)
        {
            List<UkraineProm> proms = new List<UkraineProm>();
            proms.Add(new UkraineProm("1", "1")
            {
                PromType = "Грузовые автомобили",
                MeasureUnits = "тыс. шт.",
                Year1913 = 10,
                Year1928 = 0,
                Year1940 = 0,
                Year1959 = 12.6
            });
            proms.Add(new UkraineProm("1", "2")
            {
                PromType = "Цемент",
                MeasureUnits = "тыс. тонн",
                Year1913 = 269,
                Year1928 = 297,
                Year1940 = 1218,
                Year1959 = 7017
            });
            proms.Add(new UkraineProm("1", "3")
            {
                PromType = "Кирпич",
                MeasureUnits = "млрд. шт.",
                Year1913 = 0.6,
                Year1928 = 0.7,
                Year1940 = 1.6,
                Year1959 = 6.3
            });
            proms.Add(new UkraineProm("1", "4")
            {
                PromType = "Ткани х/б",
                MeasureUnits = "млн. м.",
                Year1913 = 4.7,
                Year1928 = 2,
                Year1940 = 13.8,
                Year1959 = 88.2
            });
            proms.Add(new UkraineProm("1", "5")
            {
                PromType = "Ткани шерстянные",
                MeasureUnits = "млн. м.",
                Year1913 = 5.3,
                Year1928 = 2,
                Year1940 = 12,
                Year1959 = 17.7
            });
            proms.Add(new UkraineProm("1", "6")
            {
                PromType = "Сахар-песок",
                MeasureUnits = "тыс. тонн",
                Year1913 = 1107,
                Year1928 = 1041,
                Year1940 = 1580,
                Year1959 = 4103
            });
            foreach (UkraineProm prom in proms)
            {
                await SamplesUtils.InsertOrMergeEntityAsync(table, prom);
            }

            //Task 1
            Console.WriteLine("Task1");
            double minPromCount1913 = double.MaxValue;
            UkraineProm minProm = null;
            for(int i = 1; i < 7; i++)
            {
                var ukProm = await SamplesUtils.RetrieveEntityUsingPointQueryAsync(table, "1", i.ToString());
                if(ukProm.Year1913 < minPromCount1913)
                {
                    minPromCount1913 = ukProm.Year1913;
                    minProm = ukProm;
                }
            }
            Console.WriteLine($"Min prom in 1913 - {minProm.PromType}, {minProm.MeasureUnits}, {minProm.Year1913}\n");

            //Task 2
            Console.WriteLine("Task2");
            for(int i = 1; i < 7; i++)
            {
                var ukProm = await SamplesUtils.RetrieveEntityUsingPointQueryAsync(table, "1", i.ToString());
                if(ukProm.Year1940 > 100)
                {
                    Console.WriteLine($"Prod > 100 in 1940 - {ukProm.PromType}, {ukProm.MeasureUnits}, {ukProm.Year1913}\n");
                }
            }
        }
    }
}
