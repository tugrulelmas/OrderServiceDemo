﻿using Microsoft.AspNetCore.Mvc;
using OrderService.EventHandlers;
using OrderService.Events;
using System.Collections.Generic;

namespace OrderService.Controllers {
    [ApiController]
    [Route("[controller]")]
    public class Order6Controller : ControllerBase {
        private readonly IEnumerable<IEventHandler<OrderCreated>> eventHandlers;

        public Order6Controller(IEnumerable<IEventHandler<OrderCreated>> eventHandlers) {
            this.eventHandlers = eventHandlers;
        }

        [HttpPost]
        public ActionResult Create(CreateOrderRequest createOrderRequest) {
            var orderCreated = new OrderCreated(createOrderRequest.Id, createOrderRequest.NotificationType, createOrderRequest.Content);

            foreach (var eventHandlerItem in eventHandlers) {
                eventHandlerItem.Handle(orderCreated);
            }

            return Ok();
        }
    }
}
