using System;
using System.Collections.Generic;

namespace OrderService.Strategies {
    public class NotificationFactory : INotificationFactory {

        private readonly IDictionary<string, INotificationStrategy> notifications;

        public NotificationFactory(IEnumerable<INotificationStrategy> notificationStrategies) {
            notifications = new Dictionary<string, INotificationStrategy>();
            foreach (var notificationStrategyItem in notificationStrategies) {
                notifications.Add(notificationStrategyItem.Name, notificationStrategyItem);
            }
        }

        public INotificationStrategy Create(string notificationType) {
            if (!notifications.ContainsKey(notificationType))
                throw new Exception($"{notificationType} is not a valid type for notification strategy");

            return notifications[notificationType];
        }
    }
}
