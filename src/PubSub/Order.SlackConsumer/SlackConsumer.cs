using EasyNetQ;
using EasyNetQ.AutoSubscribe;
using Order.Core;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Order.SlackConsumer {
    public class SlackConsumer : IConsumeAsync<OrderCreated> {
        private readonly IBus bus;

        public SlackConsumer(IBus bus) {
            this.bus = bus;
        }

        public async Task ConsumeAsync(OrderCreated message, CancellationToken cancellationToken = default) {
            Thread.Sleep(3000);
            var historyCreated = new HistoryCreated { Text = $"Sent a slack message with content '{message.Content}' for order with id {message.Id}" };
            await bus.PubSub.PublishAsync(historyCreated);
            Console.WriteLine($"{DateTime.Now:HH:mm:ss} -- {historyCreated.Text}");
        }
    }
}
