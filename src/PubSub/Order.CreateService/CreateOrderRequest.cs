using System;

namespace Order.CreateService {
    public class CreateOrderRequest {
        public int Id { get; set; }

        public string NotificationType { get; set; }

        public string Content { get; set; }
    }
}
