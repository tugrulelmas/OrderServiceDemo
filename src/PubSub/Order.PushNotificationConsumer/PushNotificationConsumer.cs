using EasyNetQ;
using EasyNetQ.AutoSubscribe;
using Order.Core;
using System.Threading;
using System.Threading.Tasks;

namespace Order.SlackConsumer {
    public class PushNotificationConsumer : IConsumeAsync<OrderCreated> {
        private readonly IBus bus;

        public PushNotificationConsumer(IBus bus) {
            this.bus = bus;
        }

        [ForTopic("created.pushnotification")]
        public async Task ConsumeAsync(OrderCreated message, CancellationToken cancellationToken = default) {
            await bus.PubSub.PublishAsync(new HistoryCreated { Text = $"Sent a push notification with content '{message.Content}' for order with id {message.Id}" });
        }
    }
}
