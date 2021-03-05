using EasyNetQ;
using Microsoft.AspNetCore.Mvc;
using Order.Core;
using System.Threading.Tasks;

namespace Order.CreateService.Controllers {
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase {
        private readonly IBus bus;

        public OrderController(IBus bus) {
            this.bus = bus;
        }

        [HttpPost]
        public async Task<ActionResult> Create(CreateOrderRequest createOrderRequest) {
            var orderCreated = new OrderCreated(createOrderRequest.Id, createOrderRequest.NotificationType, createOrderRequest.Content);
            await bus.PubSub.PublishAsync(orderCreated, $"created.{orderCreated.NotificationType.ToLowerInvariant()}");
            return Ok();
        }
    }
}
