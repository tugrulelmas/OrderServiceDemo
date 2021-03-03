namespace OrderService.Events {
    public class OrderCreated {
        public OrderCreated(int id, string notificationType, string content ) {
            Id = id;
            NotificationType = notificationType;
            Content = content;
        }

        public int Id { get; set; }

        public string NotificationType { get; }

        public string Content { get; }
    }
}
