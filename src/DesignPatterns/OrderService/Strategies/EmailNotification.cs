using OrderService.Services;

namespace OrderService.Strategies {
    public class EmailNotification : INotificationStrategy, IEmailService {
        private readonly IHistoryService historyService;

        public EmailNotification(IHistoryService historyService) {
            this.historyService = historyService;
        }

        public string Name => "email";

        public void Notify(int orderId, string content) {
            historyService.Push($"Sent an email with content '{content}' for order with id {orderId}");
        }

        public void SendEmail(int orderId, string content) {
            Notify(orderId, content);
        }
    }
}
