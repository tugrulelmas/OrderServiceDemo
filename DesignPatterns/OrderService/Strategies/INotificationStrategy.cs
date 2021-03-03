namespace OrderService.Strategies {
    public interface INotificationStrategy {
        void Notify(int orderId, string content);

        string Name { get; }
    }
}
