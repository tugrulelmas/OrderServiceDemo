using EasyNetQ;
using EasyNetQ.AutoSubscribe;
using Order.Core;
using System.Threading;
using System.Threading.Tasks;

namespace Order.NotificationConsumer {
    public class EmailOfferConsumer : IConsumeAsync<OrderCreated> {
        private readonly IBus bus;

        public EmailOfferConsumer(IBus bus) {
            this.bus = bus;
        }

        [ForTopic("created.sms")]
        public async Task ConsumeAsync(OrderCreated message, CancellationToken cancellationToken = default) {
            await bus.PubSub.PublishAsync(new HistoryCreated { Text = $"Sent an email with content 'Would you like to get an email instead of sms?' for order with id {message.Id}" });
        }
    }
}
