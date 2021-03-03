namespace OrderService.Strategies {
    public interface INotificationFactory {
        INotificationStrategy Create(string notificationType);
    }
}
