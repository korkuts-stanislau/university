using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using CosmosTableSamples;
using CosmosTableSamples.Models;
using Microsoft.WindowsAzure.Storage;

namespace FunctionApp
{
    public static class Function
    {
        [FunctionName("Delete")]
        public static async System.Threading.Tasks.Task RunAsync([TimerTrigger("*/5 * * * * *")]TimerInfo myTimer, ILogger log)
        {
            EntityOperations operations = new EntityOperations();
            try
            {
                var phonesTable = await Common.CreateTableAsync("phones");
                var phones = operations.GetPhones(phonesTable);
                await operations.DeletePhoneAsync(phonesTable, phones[phones.Count - 1]);
            }
            catch (StorageException e)
            {
                Console.WriteLine(e.Message);
                Console.ReadLine();
                throw;
            }
        }
    }
}
