using EasyNetQ;
using EasyNetQ.AutoSubscribe;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Reflection;

namespace Order.Core {
    public static class Extensions {
        public static void UseAutoSubscriber(this IServiceProvider serviceProvider) {
            var bus = serviceProvider.GetService<IBus>();
            var subscriber = new AutoSubscriber(bus, "order-consumer") {
                GenerateSubscriptionId = c => AppDomain.CurrentDomain.FriendlyName + c.ConcreteType.Name,
                AutoSubscriberMessageDispatcher = new MessageDispatcher(serviceProvider)
            };
            subscriber.Subscribe(new Assembly[] { Assembly.GetEntryAssembly() });
        }

        public static IApplicationBuilder UseAutoSubscriber(this IApplicationBuilder applicationBuilder) {
            applicationBuilder.ApplicationServices.UseAutoSubscriber();
            return applicationBuilder;
        }

        public static IServiceCollection AddPubSub(this IServiceCollection services) {
            return services.AddSingleton(RabbitHutch.CreateBus("host=localhost;username=admin;password=1234"))
                .Scan(scan => scan.FromEntryAssembly().AddClasses(classes => classes.AssignableTo(typeof(IConsumeAsync<>))).AsSelf())
                .Scan(scan => scan.FromEntryAssembly().AddClasses(classes => classes.AssignableTo(typeof(IConsume<>))).AsSelf());
        }
    }
}