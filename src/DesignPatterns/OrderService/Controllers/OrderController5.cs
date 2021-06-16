using Microsoft.AspNetCore.Mvc;
using OrderService.Services;
using OrderService.Strategies;

namespace OrderService.Controllers {
    [ApiController]
    [Route("[controller]")]
    public class Order5Controller : ControllerBase {
        private readonly IHistoryService historyService;
        private readonly INotificationFactory notificationFactory;

        public Order5Controller(IHistoryService historyService, INotificationFactory notificationFactory) {
            this.historyService = historyService;
            this.notificationFactory = notificationFactory;
        }

        [HttpPost]
        public ActionResult Create(CreateOrderRequest createOrderRequest) {
            CreateOrder(createOrderRequest);

            SendSlackMessage(createOrderRequest.Id, createOrderRequest.Content);

            var notificationStrategy = notificationFactory.Create(createOrderRequest.NotificationType);
            notificationStrategy.Notify(createOrderRequest.Id, createOrderRequest.Content);

            return Ok();
        }

        private void CreateOrder(CreateOrderRequest createOrderRequest) {
            historyService.Push($"Order with id {createOrderRequest.Id} is created");
        }

        private void SendSlackMessage(int orderId, string content) {
            historyService.Push($"Sent a slack message with content '{content}' for order with id {orderId}");
        }
    }
}
