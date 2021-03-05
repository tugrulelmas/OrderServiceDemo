using EasyNetQ;
using EasyNetQ.AutoSubscribe;
using Order.Core;
using System.Threading;
using System.Threading.Tasks;

namespace Order.NotificationConsumer {
    public class CreateOrderConsumer : IConsumeAsync<OrderCreated> {
        private readonly IBus bus;

        public CreateOrderConsumer(IBus bus) {
            this.bus = bus;
        }

        public async Task ConsumeAsync(OrderCreated message, CancellationToken cancellationToken = default) {
            await bus.PubSub.PublishAsync(new HistoryCreated { Text = $"Order with id {message.Id} is created" });
        }
    }
}
