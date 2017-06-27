using Microsoft.ServiceBus.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueueReceiverNotCore
{
    class Program
    {

        public static QueueClient client;
        public const string ServiceBusConnectionString = "Endpoint=sb://tyrecheck.servicebus.windows.net/;SharedAccessKeyName=Listen;SharedAccessKey=dYwpPdnCNE9kle3buUIPtndSjOlCszrggrVj20ixj/o=";
        public const string QueueName = "Schedule";
        private static MessagingFactory factory = MessagingFactory.CreateFromConnectionString(ServiceBusConnectionString);
        /*
         <add key = "ida:ServiceBus" value="Endpoint=sb://tyrecheck.servicebus.windows.net/;SharedAccessKeyName=access;SharedAccessKey=7E8STahs3mu1MtKOckGlh4mWcNC8D5RyBUc1wkzUZbo=;EntityPath=schedule" />
        <add key = "ida:QueueName" value="Schedule" />
    */    
    static void Main(string[] args)
        {
           // MainAsync().GetAwaiter().GetResult();
           while(true)
                MainAsync().GetAwaiter().GetResult();
        }
         
            public void ReceiveMessages()
            {

           
            }

      
        private static async Task MainAsync()
        {
             
            MessageReceiver testQueueReceiver = factory.CreateMessageReceiver("Schedule");
            while (true)
            {
               


                using (BrokeredMessage retrievedMessage = testQueueReceiver.Receive())
                {
                    try
                    {
                       
                        Console.WriteLine("Message(s) Retrieved: " + retrievedMessage.GetBody<string>());
                        retrievedMessage.Complete();
                        System.Threading.Thread.Sleep(1000);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                        retrievedMessage.Abandon();
                    }
                }
            }
        }
        private static async Task MainAsync2()
        {
            var client1 = QueueClient.CreateFromConnectionString(ServiceBusConnectionString, QueueName);
            var options = new OnMessageOptions();
            options.AutoComplete = false;

            try
            {
                client.OnMessage(mes =>
                {

                    Console.WriteLine("Message(s) Retrieved: " + mes.GetBody<string>());

                }, options);
            }
            catch(Exception e)
            {
                //Console.WriteLine("no items on the queue");

            }
        }
    }
}
