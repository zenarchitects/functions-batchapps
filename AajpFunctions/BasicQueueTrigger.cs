using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;

namespace AajpFunctions
{
    public static class BasicQueueTrigger
    {
        [FunctionName("BasicQueueTrigger")]
        public static void Run([QueueTrigger("basic-queue-items")]string myQueueItem, TraceWriter log)
        {
            log.Info($"C# Queue trigger function processed: {myQueueItem}");
        }
    }
}
