using EasyNetQ.AutoSubscribe;
using Order.Core;
using Order.HistoryService.Services;
using System.Threading;

namespace Order.HistoryService.Consumers {
    public class HistoryConsumer : IConsume<HistoryCreated> {
        private readonly IHistoryService historyService;

        public HistoryConsumer(IHistoryService historyService) {
            this.historyService = historyService;
        }

        public void Consume(HistoryCreated message, CancellationToken cancellationToken = default) {
            historyService.Push(message.Text);
        }
    }
}
