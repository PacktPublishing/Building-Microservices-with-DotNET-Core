using System.Configuration;
using Microsoft.ServiceBus.Messaging;

namespace FlixOne.BookStore.MessageSender
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var connectionString = ConfigurationManager.AppSettings["Microsoft.ServiceBus.ConnectionString"];
            var queueName = ConfigurationManager.AppSettings["FlixOneQueueName"];

            var client = QueueClient.CreateFromConnectionString(connectionString, queueName);
            var message = new BrokeredMessage("A message from FlixOne.BookStore.MessageSender");

            client.Send(message);
        }
    }
}