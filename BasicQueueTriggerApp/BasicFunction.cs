using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;

namespace BasicQueueTriggerApp
{
    public static class BasicFunction
    {
        [FunctionName("BasicFunction")]
        public static void Run([QueueTrigger("basic-queue-items", Connection = "")]string myQueueItem, TraceWriter log)
        {
            log.Info($"C# Queue trigger function processed: {myQueueItem}");
        }
    }
}
