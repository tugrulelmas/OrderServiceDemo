using EasyNetQ;
using EasyNetQ.AutoSubscribe;
using Order.Core;
using System.Threading;
using System.Threading.Tasks;

namespace Order.NotificationConsumer {
    public class SmsConsumer : IConsumeAsync<OrderCreated> {
        private readonly IBus bus;

        public SmsConsumer(IBus bus) {
            this.bus = bus;
        }

        [ForTopic("created.sms")]
        public async Task ConsumeAsync(OrderCreated message, CancellationToken cancellationToken = default) {
            await bus.PubSub.PublishAsync(new HistoryCreated { Text = $"Sent an sms with content '{message.Content}' for order with id {message.Id}" });
        }
    }
}
