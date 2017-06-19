using System;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.EventHubs;

namespace FlixOne.BookStore.EventHubSender
{
    public class Program
    {
        private static readonly string _connectionString = "my Eventub connection string";
        private static readonly string _eventHubEntityPath = "my EventHub entity path";
        private static EventHubClient _eventHubClient;

        public static void Main(string[] args)
        {
            InitiateEventMessageSenderUsingAyncMethod(args).GetAwaiter().GetResult();
        }

        private static async Task InitiateEventMessageSenderUsingAyncMethod(string[] args)
        {
            var connectionStringBuilder = new EventHubsConnectionStringBuilder(_connectionString)
            {
                EntityPath = _eventHubEntityPath
            };

            _eventHubClient = EventHubClient.CreateFromConnectionString(connectionStringBuilder.ToString());

            await SendMessagesToEventHub();

            await _eventHubClient.CloseAsync();

            Console.WriteLine("Press any key to exit.");
            Console.ReadLine();
        }

        private static async Task SendMessagesToEventHub()
        {
            try
            {
                var message = "A event from FlixOne.BookStore.EventHubSender";
                Console.WriteLine($"Sending message: {message}");
                await _eventHubClient.SendAsync(new EventData(Encoding.UTF8.GetBytes(message)));
            }
            catch (Exception exception)
            {
                Console.WriteLine($"{DateTime.Now} > Exception: {exception.Message}");
            }

            await Task.Delay(10);
        }
    }
}