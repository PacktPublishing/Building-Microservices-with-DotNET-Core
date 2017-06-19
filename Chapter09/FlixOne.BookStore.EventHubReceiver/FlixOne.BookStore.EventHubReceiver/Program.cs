using System;
using System.Threading.Tasks;
using Microsoft.Azure.EventHubs;
using Microsoft.Azure.EventHubs.Processor;

namespace FlixOne.BookStore.EventHubReceiver
{
    public class Program: IEventProcessor
    {
        private const string ConnectionString = "my connection string";
        private const string EntityPath = "my event hub path name";
        private const string StorageContainerName = "storage container name";
        private const string StorageAccountName = "Storage account name";
        private const string StorageAccountKey = "Storage account key";

        private static readonly string StorageConnectionString = string.Format("DefaultEndpointsProtocol=https;AccountName={0};AccountKey={1}", StorageAccountName, StorageAccountKey);

        public static void Main(string[] args)
        {
            RegisterEventUsingAsync(args).GetAwaiter().GetResult();
        }

        private static async Task RegisterEventUsingAsync(string[] args)
        {
            Console.WriteLine("Registering EventProcessor...");

            var eventProcessorHost = new EventProcessorHost(
                EntityPath,
                PartitionReceiver.DefaultConsumerGroupName,
                ConnectionString,
                StorageConnectionString,
                StorageContainerName);

            await eventProcessorHost.RegisterEventProcessorAsync<EventHubReceiver>();

            Console.WriteLine("Receiving. Press enter key to stop worker.");
            Console.ReadLine();

            // Disposes of the Event Processor Host
            await eventProcessorHost.UnregisterEventProcessorAsync();
        }
    }
}