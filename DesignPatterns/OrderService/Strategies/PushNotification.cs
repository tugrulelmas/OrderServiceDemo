using OrderService.Services;

namespace OrderService.Strategies {
    public class PushNotification : INotificationStrategy {
        private readonly IHistoryService historyService;

        public PushNotification(IHistoryService historyService) {
            this.historyService = historyService;
        }

        public string Name => "pushNotification";

        public void Notify(int orderId, string content) {
            historyService.Push($"Sent a push notification with content '{content}' for order with id {orderId}");
        }
    }
}
