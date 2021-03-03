using OrderService.Services;

namespace OrderService.Strategies {
    public class SmsNotification : INotificationStrategy {
        private readonly IHistoryService historyService;

        public SmsNotification(IHistoryService historyService) {
            this.historyService = historyService;
        }

        public string Name => "sms";

        public void Notify(int orderId, string content) {
            historyService.Push($"Sent an sms with content '{content}' for order with id {orderId}");
        }
    }
}
