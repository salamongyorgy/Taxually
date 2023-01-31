using Taxually.TechnicalTest.Model;

namespace Taxually.TechnicalTest.Controllers.Parameters {
    public class TaxuallyQueueClient {

        internal Task EnqueueAsync<TPayload> (string queueName, TPayload payload) {
            // Code to send to message queue removed for brevity
            return Task.CompletedTask;
        }
    }
}