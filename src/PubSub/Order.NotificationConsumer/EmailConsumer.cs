using EasyNetQ;
using EasyNetQ.AutoSubscribe;
using Order.Core;
using System.Threading;
using System.Threading.Tasks;

namespace Order.NotificationConsumer {
    public class EmailConsumer : IConsumeAsync<OrderCreated> {
        private readonly IBus bus;

        public EmailConsumer(IBus bus) {
            this.bus = bus;
        }

        [ForTopic("created.email")]
        public async Task ConsumeAsync(OrderCreated message, CancellationToken cancellationToken = default) {
            await bus.PubSub.PublishAsync(new HistoryCreated { Text = $"Sent an email with content '{message.Content}' for order with id {message.Id}" });
        }
    }
}
