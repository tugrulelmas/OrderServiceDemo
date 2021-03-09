using Microsoft.AspNetCore.Mvc;
using OrderService.Services;
using System;

namespace OrderService.Controllers {
    [ApiController]
    [Route("[controller]")]
    public class OrderController4 : ControllerBase {
        private readonly IHistoryService historyService;

        public OrderController4(IHistoryService historyService) {
            this.historyService = historyService;
        }

        [HttpPost]
        public ActionResult Create(CreateOrderRequest createOrderRequest) {
            CreateOrder(createOrderRequest);

            SendSlackMessage(createOrderRequest.Id, createOrderRequest.Content);

            if (createOrderRequest.NotificationType.Equals("email", StringComparison.OrdinalIgnoreCase)) {
                SendEmail(createOrderRequest.Id, createOrderRequest.Content);
            } else if (createOrderRequest.NotificationType.Equals("sms", StringComparison.OrdinalIgnoreCase)) {
                SendSms(createOrderRequest.Id, createOrderRequest.Content);
                SendEmail(createOrderRequest.Id, "Would you like to get an email instead of sms");
            } else if (createOrderRequest.NotificationType.Equals("pushNotification", StringComparison.OrdinalIgnoreCase)) {
                SendPushNotification(createOrderRequest.Id, createOrderRequest.Content);
            }

            return Ok();
        }

        private void CreateOrder(CreateOrderRequest createOrderRequest) {
            historyService.Push($"Order with id {createOrderRequest.Id} is created");
        }

        private void SendEmail(int orderId, string content) {
            historyService.Push($"Sent an email with content '{content}' for order with id {orderId}");
        }

        private void SendSms(int orderId, string content) {
            historyService.Push($"Sent an sms with content '{content}' for order with id {orderId}");
        }

        private void SendPushNotification(int orderId, string content) {
            historyService.Push($"Sent a push notification with content '{content}' for order with id {orderId}");
        }

        private void SendSlackMessage(int orderId, string content) {
            historyService.Push($"Sent a slack message with content '{content}' for order with id {orderId}");
        }
    }
}
