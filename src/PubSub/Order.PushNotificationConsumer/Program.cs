using Microsoft.Extensions.DependencyInjection;
using Order.Core;
using System;

namespace Order.PushNotificationConsumer {
    class Program {
        static void Main(string[] args) {
            using (var services = RegisterServices()) {
                services.UseAutoSubscriber();
                Console.ReadLine();
            }
        }

        private static ServiceProvider RegisterServices() {
            return new ServiceCollection()
                .AddPubSub()
                .BuildServiceProvider();
        }
    }
}
