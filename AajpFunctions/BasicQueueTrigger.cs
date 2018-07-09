using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;

namespace AajpFunctions
{
    public static class BasicQueueTrigger
    {
        [FunctionName("BasicQueueTrigger")]
        public static void Run([QueueTrigger("basic-queue-items")]string myQueueItem, ILogger log)
        {
            log.LogInformation("C# Queue trigger function processed: {myQueueItem}", myQueueItem);
        }
    }
}
