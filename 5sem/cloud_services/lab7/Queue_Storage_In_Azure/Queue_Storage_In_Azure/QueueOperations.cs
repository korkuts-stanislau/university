using Microsoft.Azure.Storage;
using Microsoft.Azure.Storage.Queue;
using System;


namespace Queue_Storage_In_Azure
{
    public class QueueOperations
    {
        public const string connstring = "AccountName=devstoreaccount1;AccountKey=Eby8vdM02xNOcqFlqUwJPLlmEtlCDXJ1OUzFT50uSRZ6IFsuFq2UVErCz4I6tq/K1SZFPTOtr/KBHBeksoGMGw==;DefaultEndpointsProtocol=http;BlobEndpoint=http://127.0.0.1:10000/devstoreaccount1;QueueEndpoint=http://127.0.0.1:10001/devstoreaccount1;TableEndpoint=http://127.0.0.1:10002/devstoreaccount1;";

        public const string queueName = "stringqueue";
        public void AddMessage(string message)
        {
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(connstring);
            CloudQueueClient cloudQueueClient = storageAccount.CreateCloudQueueClient();
            CloudQueue cloudQueue = cloudQueueClient.GetQueueReference(queueName);
            CloudQueueMessage queueMessage = new CloudQueueMessage(message);
            cloudQueue.AddMessage(queueMessage);
        }


        public CloudQueueMessage RetrieveMessage()
        {
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(connstring);
            CloudQueueClient cloudQueueClient = storageAccount.CreateCloudQueueClient();
            CloudQueue cloudQueue = cloudQueueClient.GetQueueReference(queueName);
            CloudQueueMessage queueMessage = cloudQueue.GetMessage();
            Console.WriteLine(queueMessage.AsString);
            cloudQueue.DeleteMessage(queueMessage);
            return queueMessage;
        }
    }
}
