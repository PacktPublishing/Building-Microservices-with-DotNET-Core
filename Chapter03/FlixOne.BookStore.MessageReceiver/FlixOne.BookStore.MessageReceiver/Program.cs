using System;
using System.Configuration;
using Microsoft.ServiceBus.Messaging;

namespace FlixOne.BookStore.MessageReceiver
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var connectionString = ConfigurationManager.AppSettings["Microsoft.ServiceBus.ConnectionString"];
            var queueName = ConfigurationManager.AppSettings["QueueName"];

            var client = QueueClient.CreateFromConnectionString(connectionString, queueName);

            client.OnMessage(message =>
            {
                Console.WriteLine($"Message: {message.GetBody<string>()}");
                Console.WriteLine($"Message id: {message.MessageId}");
            });

            Console.ReadLine();
        }
    }
}