using OrderService.Events;
using OrderService.Services;

namespace OrderService.EventHandlers {
    public class SlackEventHandler : IEventHandler<OrderCreated> {
        private readonly IHistoryService historyService;

        public SlackEventHandler(IHistoryService historyService) {
            this.historyService = historyService;
        }

        public void Handle(OrderCreated eventInstance) {
            historyService.Push($"Sent a slack message with content '{eventInstance.Content}' for order with id {eventInstance.Id}");
        }
    }
}
