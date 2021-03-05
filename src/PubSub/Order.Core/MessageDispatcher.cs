using EasyNetQ.AutoSubscribe;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Order.Core {
    class MessageDispatcher : IAutoSubscriberMessageDispatcher {
        private readonly IServiceProvider serviceProvider;

        public MessageDispatcher(IServiceProvider serviceProvider) {
            this.serviceProvider = serviceProvider;
        }

        void IAutoSubscriberMessageDispatcher.Dispatch<TMessage, TConsumer>(TMessage message, CancellationToken cancellationToken) {
            var consumer = serviceProvider.GetService<TConsumer>();
            consumer.Consume(message, cancellationToken);
        }

        async Task IAutoSubscriberMessageDispatcher.DispatchAsync<TMessage, TConsumer>(TMessage message, CancellationToken cancellationToken) {
            var consumer = serviceProvider.GetService<TConsumer>();
            await consumer.ConsumeAsync(message, cancellationToken);
        }
    }
}
