using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.ServiceBus.Messaging;
using Microsoft.IdentityModel.Protocols;
using System.Configuration;
using Microsoft.ServiceBus;

namespace WebApp_Queue_DotNet.Controllers
{
    public class PdfController : Controller
    {

     
        public void SendToQueue()
        {
            var connectionString = ConfigurationManager.AppSettings["ida:ServiceBus"];
            var queueName = ConfigurationManager.AppSettings["ida:QueueName"];

            var client = QueueClient.CreateFromConnectionString(connectionString);
            var message = new BrokeredMessage("{'name':'Joao','url':'http://google.com','timestamp':"+DateTime.Now.ToString()+"'}") { ContentType = "application/json" };
          
            client.RetryPolicy = new RetryExponential(minBackoff: TimeSpan.FromSeconds(0.1),
                                            maxBackoff: TimeSpan.FromSeconds(30),
                                            maxRetryCount: 3);
            client.Send(message);
        }
    }
}