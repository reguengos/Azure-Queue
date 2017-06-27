using Microsoft.ServiceBus.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace schedulerWindowsService
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// 
   
        private const string ServiceBusConnectionString = "{Service Bus connection string}";
        private const string QueueName = "{Queue path/name}";
        private static MessagingFactory factory = MessagingFactory.CreateFromConnectionString(ServiceBusConnectionString);


        static void Main()
        {
          
            MainAsync().GetAwaiter().GetResult();

        }

          private static async Task MainAsync()
        {
            MessageReceiver testQueueReceiver = factory.CreateMessageReceiver("samplequeue");
            while (true)
            {
                using (BrokeredMessage retrievedMessage = testQueueReceiver.Receive())
                {
                    try
                    {
                        Console.WriteLine("Message(s) Retrieved: " + retrievedMessage.GetBody<string>());
                        retrievedMessage.Complete();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                        retrievedMessage.Abandon();
                    }
                }
            }
        }
    }
}
