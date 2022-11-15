using Microsoft.Azure.ServiceBus;
using Microsoft.Azure.ServiceBus.Core;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using System.Text;

namespace ServiceBusTriggerApp
{
    public class ServiceBusTriggerApp
    {
        [FunctionName("ServiceBusTriggerApp")]
        public void Run([ServiceBusTrigger("myqueue", Connection = "ServiceBusConnection")]Message message, MessageReceiver messageReceiver, ILogger log)
        {
            string payload = Encoding.UTF8.GetString(message.Body);
            log.LogInformation($"C# ServiceBus queue trigger function processed message: {payload}");
            messageReceiver.CompleteAsync(message.SystemProperties.LockToken);
        }
    }
}
