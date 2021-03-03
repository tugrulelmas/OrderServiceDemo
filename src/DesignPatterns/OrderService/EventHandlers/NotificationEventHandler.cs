using OrderService.Events;
using OrderService.Strategies;

namespace OrderService.EventHandlers {
    public class NotificationEventHandler : IEventHandler<OrderCreated> {
        private readonly INotificationFactory notificationFactory;

        public NotificationEventHandler(INotificationFactory notificationFactory) {
            this.notificationFactory = notificationFactory;
        }

        public void Handle(OrderCreated eventInstance) {
            var notificationStrategy = notificationFactory.Create(eventInstance.NotificationType);
            notificationStrategy.Notify(eventInstance.Id, eventInstance.Content);
        }
    }
}
