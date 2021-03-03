using OrderService.Events;
using OrderService.Services;

namespace OrderService.EventHandlers {
    public class CreateEventHandler : IEventHandler<OrderCreated> {
        private readonly IHistoryService historyService;

        public CreateEventHandler(IHistoryService historyService) {
            this.historyService = historyService;
        }

        public void Handle(OrderCreated eventInstance) {
            historyService.Push($"Order with id {eventInstance.Id} is created");
        }
    }
}
