using OrderService.Services;

namespace OrderService.Strategies {
    public class SmsNotificationEmailDecorator : INotificationStrategy {
        private readonly INotificationStrategy notificationStrategy;
        private readonly IEmailService emailService;

        public SmsNotificationEmailDecorator(INotificationStrategy notificationStrategy, IEmailService emailService) {
            this.notificationStrategy = notificationStrategy;
            this.emailService = emailService;
        }

        public string Name => notificationStrategy.Name;

        public void Notify(int orderId, string content) {
            notificationStrategy.Notify(orderId, content);
            emailService.SendEmail(orderId, "Would you like to get an email instead of sms");
        }
    }
}
